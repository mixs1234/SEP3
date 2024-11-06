using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3.orders.Model;
using sep3.orders.Infrastructure;

namespace sep3.orders.Services;

public class PaymentEFRepository : IPaymentRepository
{
    private readonly OrdersContext _context;

    public PaymentEFRepository(OrdersContext context)
    {
        _context = context;
        if (_context == null)
            _context = OrdersContext.GetInstance(null);
    }
    
    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
        // TODO: Event
    }

    public async Task<Payment> CreatePaymentAsync(int? orderId, string paymentMethod, DateTimeOffset? timestamp, string paymentIdentifier,
        string paymentConfirmation, double? amount)
    {
        if (orderId.HasValue && !string.IsNullOrWhiteSpace(paymentMethod) && timestamp.HasValue &&
            !string.IsNullOrWhiteSpace(paymentIdentifier))
        {
            if (!_context.Orders.Any(o => o.Id == orderId))
                throw new Exception();
            Payment payment = new Payment()
            {
                OrderId = orderId.Value,
                PaymentMethod = paymentMethod,
                Timestamp = timestamp.Value,
                PaymentIdentifier = paymentIdentifier
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
            //TODO: Event
        }
        else
            throw new NullReferenceException();
    }

    public async Task<List<Payment>> GetPaymentsAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task<Payment> GetPaymentAsync(int? id)
    {
        if (id.HasValue)
            return await _context.Payments.Where(p => p.Id == id.Value).FirstOrDefaultAsync();
        else
            throw new ArgumentNullException(nameof(id));
    }

    public async Task UpdatePaymentAsync(int? id, int? orderId, string paymentMethod, DateTimeOffset? timestamp,
        string paymentIdentifier, string paymentConfirmation, double? amount)
    {
        if (id.HasValue && orderId.HasValue && !string.IsNullOrWhiteSpace(paymentMethod) && timestamp.HasValue &&
            !string.IsNullOrWhiteSpace(paymentIdentifier) && amount.HasValue)
        {
            Payment payment = await GetPaymentAsync(id) ?? throw new InvalidOperationException();
            payment.OrderId = orderId.Value;
            payment.PaymentMethod = paymentMethod;
            payment.Timestamp = timestamp.Value;
            payment.PaymentIdentifier = paymentIdentifier;
            await _context.SaveChangesAsync();
            //TODO: Event
        }
        else
            throw new ArgumentNullException();
    }

    public async Task DeletePaymentAsync(int? id)
    {
        if (id.HasValue)
        {
            Payment payment = await _context.Payments.Where(p => p.Id == id).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            // TODO: Event
        }
        else
            throw new ArgumentNullException(nameof(id));
    }
}
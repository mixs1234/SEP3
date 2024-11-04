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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
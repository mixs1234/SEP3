using sep3.orders.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sep3.orders.Services;

public interface IPaymentRepository
{
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task<Payment> CreatePaymentAsync(int? orderId, string paymentMethod, DateTimeOffset? timestamp, string paymentIdentifier, string paymentConfirmation, double? amount);
    Task<List<Payment>> GetPaymentsAsync();
    Task<Payment> GetPaymentAsync(int? id);
    Task UpdatePaymentAsync(int? id, int? orderId, string paymentMethod, DateTimeOffset? timestamp, string paymentIdentifier, string paymentConfirmation, double? amount);
    Task DeletePaymentAsync(int? id);
}
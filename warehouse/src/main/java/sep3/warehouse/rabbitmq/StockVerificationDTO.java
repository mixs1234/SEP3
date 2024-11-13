package sep3.warehouse.rabbitmq;

public class StockVerificationDTO {

    private long orderId;
    private boolean isInStock;

    public StockVerificationDTO() {
    }

    public StockVerificationDTO(long orderId, boolean isInStock) {
        this.orderId = orderId;
        this.isInStock = isInStock;
    }

    public long getOrderId() {
        return orderId;
    }

    public void setOrderId(long orderId) {
        this.orderId = orderId;
    }

    public boolean getIsInStock() {
        return isInStock;
    }

    public void setIsInStock(boolean isInStock) {
        this.isInStock = isInStock;
    }
}

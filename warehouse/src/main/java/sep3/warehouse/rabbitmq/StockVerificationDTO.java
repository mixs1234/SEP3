package sep3.warehouse.rabbitmq;

public class StockVerificationDTO {

    private String orderId;
    private boolean isInStock;

    public StockVerificationDTO() {
    }

    public StockVerificationDTO(String orderId, boolean isInStock) {
        this.orderId = orderId;
        this.isInStock = isInStock;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public boolean getIsInStock() {
        return isInStock;
    }

    public void setIsInStock(boolean isInStock) {
        this.isInStock = isInStock;
    }
}

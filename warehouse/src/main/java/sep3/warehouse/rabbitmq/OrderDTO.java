package sep3.warehouse.rabbitmq;

public class OrderDTO {
    private long orderId;
    private long productVariantId;
    private int quantity;

    public OrderDTO(int quantity) {
        this.quantity = quantity;
    }

    public OrderDTO(long orderId, long productVariantId, int quantity) {
        this.orderId = orderId;
        this.productVariantId = productVariantId;
        this.quantity = quantity;
    }

    public long getOrderId() {
        return orderId;
    }

    public void setOrderId(long orderId) {
        this.orderId = orderId;
    }

    public long getProductVariantId() {
        return productVariantId;
    }

    public void setProductVariantId(long productVariantId) {
        this.productVariantId = productVariantId;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }
}

package sep3.warehouse.rabbitmq;

public class OrderDTO {
    private long orderId;
    private long productVariantId;

    public OrderDTO() {
    }

    public OrderDTO(long orderId, long productVariantId) {
        this.orderId = orderId;
        this.productVariantId = productVariantId;
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

}

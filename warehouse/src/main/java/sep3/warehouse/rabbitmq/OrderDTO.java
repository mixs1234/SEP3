package sep3.warehouse.rabbitmq;

public class OrderDTO {
    private String orderId;
    private String productVariantId;

    public OrderDTO() {
    }

    public OrderDTO(String orderId, String productVariantId) {
        this.orderId = orderId;
        this.productVariantId = productVariantId;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public String getProductVariantId() {
        return productVariantId;
    }

    public void setProductVariantId(String productVariantId) {
        this.productVariantId = productVariantId;
    }

}

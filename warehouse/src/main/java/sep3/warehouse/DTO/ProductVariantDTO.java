package sep3.warehouse.DTO;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@NoArgsConstructor
@AllArgsConstructor
@Data
public class ProductVariantDTO {
    private Long id;
    private String size;
    private String material;
    private int stock;
}

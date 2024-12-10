package sep3.warehouse.DTO.productVariants;


import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.DTO.ArchiveStatus.ArchiveStatusDto;

@NoArgsConstructor
@AllArgsConstructor
@Data
public class UpdateProductVariantDto {
    private Long id;
    private String size;
    private String material;
    private int stock;
    private long  archiveStatusId;

}

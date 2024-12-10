package sep3.warehouse.DTO.ArchiveStatus;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import sep3.warehouse.entities.ArchiveStatus;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class ArchiveStatusDto {
    private Long id;
    private String status;

    public static ArchiveStatusDto mapToDto(ArchiveStatus archiveStatus) {
        ArchiveStatusDto dto = new ArchiveStatusDto();
        dto.setId(archiveStatus.getId());
        dto.setStatus(archiveStatus.getStatus());
        return dto;
    }

    public static ArchiveStatus mapToEntity(ArchiveStatusDto dto) {
        ArchiveStatus entity = new ArchiveStatus();
        entity.setId(dto.getId());
        entity.setStatus(dto.getStatus());
        return entity;
    }
}

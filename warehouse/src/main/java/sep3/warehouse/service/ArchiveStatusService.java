package sep3.warehouse.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.ArchiveStatus.ArchiveStatusDto;
import sep3.warehouse.entities.ArchiveStatus;

import java.util.List;

@RequiredArgsConstructor
@Service
public class ArchiveStatusService {
    private final ArchiveStatusRepo archiveStatus;

    public ArchiveStatus getArchiveStatusById(long id) {
        return archiveStatus.findById(id).orElseThrow(() -> new IllegalArgumentException("Archive status with id: " + id + " not found"));
    }

    public List<ArchiveStatusDto> getAllArchiveStatus() {
        return archiveStatus.findAll().stream().map(ArchiveStatusDto::mapToDto).toList();
    }
}

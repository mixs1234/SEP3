package sep3.warehouse.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import sep3.warehouse.entities.ArchiveStatus;
import sep3.warehouse.entities.ArchiveStatusHistory;
import sep3.warehouse.entities.ProductVariant;

import java.time.LocalDateTime;

@RequiredArgsConstructor
@Service
public class ArchiveStatusHistoryService {
    private final ArchiveStatusHistoryRepo archiveStatusHistoryRepo;

    public ArchiveStatusHistory createArchiveStatusHistory(ArchiveStatus archiveStatus, ProductVariant productVariant){
        ArchiveStatusHistory archiveStatusHistory = new ArchiveStatusHistory();
        archiveStatusHistory.setArchiveStatus(archiveStatus);
        archiveStatusHistory.setProductVariant(productVariant);
        archiveStatusHistory.setUpdatedAt(LocalDateTime.now());
        return archiveStatusHistoryRepo.save(archiveStatusHistory);
    }
}

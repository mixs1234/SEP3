package sep3.warehouse.service;

import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.ArchiveStatusHistory;

public interface ArchiveStatusHistoryRepo extends JpaRepository<ArchiveStatusHistory, Long> {
}

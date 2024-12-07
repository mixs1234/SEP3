package sep3.warehouse.service;

import org.springframework.data.jpa.repository.JpaRepository;
import sep3.warehouse.entities.ArchiveStatus;

public interface ArchiveStatusRepo extends JpaRepository<ArchiveStatus, Long> {
}

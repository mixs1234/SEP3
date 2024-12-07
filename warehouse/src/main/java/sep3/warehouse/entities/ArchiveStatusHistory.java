package sep3.warehouse.entities;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "Archive_Status_History")
public class ArchiveStatusHistory {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne
    @JoinColumn(name = "ArchiveStatus_id", referencedColumnName = "id")
    private ArchiveStatus archiveStatus;

    @ManyToOne
    @JoinColumn(name = "ProductVariant_id", referencedColumnName = "id")
    private ProductVariant productVariant;

    @Column(nullable = false)
    private LocalDateTime updatedAt;
}

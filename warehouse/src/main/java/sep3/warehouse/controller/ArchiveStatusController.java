package sep3.warehouse.controller;

import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import sep3.warehouse.DTO.ArchiveStatus.ArchiveStatusDto;
import sep3.warehouse.service.ArchiveStatusService;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/api/archiveStatuses")
public class ArchiveStatusController {
    private final ArchiveStatusService archiveStatusService;

    @GetMapping
    public List<ArchiveStatusDto> getArchiveStatus() {
        return archiveStatusService.getAllArchiveStatus();
    }
}

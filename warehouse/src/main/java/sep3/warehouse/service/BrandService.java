package sep3.warehouse.service;


import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;

import org.springframework.stereotype.Service;
import sep3.warehouse.DTO.brands.BrandDTO;
import sep3.warehouse.entities.Brand;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class BrandService {
    private final BrandRepo brandService;

    public BrandDTO findById(Long id) {
        Brand brand = brandService.findById(id).orElseThrow(()-> new EntityNotFoundException("brand with " + id +  "not found"));

        return BrandDTO.mapBrandToBrandDTO(brand);
    }

    public List<BrandDTO> findAll() {
        return brandService.findAll().stream().map(BrandDTO::mapBrandToBrandDTO).collect(Collectors.toList());
    }


}

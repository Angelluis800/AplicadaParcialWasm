using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9ñÑ\s]+$")]
    [Required(ErrorMessage = "Este Campo Debe Contener una Descripción")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este Campo Debe Contener un Costo")]
    [Range(0.001, 10000000, ErrorMessage = "Ingrese un valor mayor a 0.001 y menor o igual a 10,000,000")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "Este Campo Debe Contener un Porciento de Ganancia")]
    [Range(0.01, 100, ErrorMessage = "Solo se permite de 0.01 a 100")]
    public double Ganancia { get; set; }

    [Range(0, 1000000000, ErrorMessage = "Ingrese un valor mayor a 0 y menor o igual a 1,000,000,000")]
    public double Precio { get; set; }
}

namespace LexingtonPreschoolAcademy_Database;

using System;
using System.ComponentModel.DataAnnotations;


public class BaseTable
{
    [Key]
    [Required]
    public int Id { get; set; }

    [DataType(DataType.DateTime)]
    [Required]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    [Required]
    public DateTime UpdatedAt { get; set; }
}
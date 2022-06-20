using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }


        // {0} = nome do atributo, {1} = maximo caracteres, {2} minimo caracteres
        [Required(ErrorMessage = "{0} required!")] //Campo obrigatorio (required)
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")] //Limitacao de tamanho do nome (stringlenght)
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        [EmailAddress(ErrorMessage = "Enter a valid email!")] //valida a existencia do email
        [DataType(DataType.EmailAddress)] //formata como email
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        [Display(Name = "Birth Date")] //formata o nome da forma como quisermos
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //formata a data nos padroes estabelecidos (nesse caso padrao do Brasil)
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required!")]
        [Range(100.0, 50000.00, ErrorMessage = "{0} must be from {1} to {2}")] //valida se o salario esta entre 100(minimo) e 50000(maximo)
        [Display(Name = "Base Salary")] //formata o nome da forma como quisermos
        [DisplayFormat(DataFormatString = "{0:N}")] //duas casas decimais
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department Id")] //formata o nome da forma como quisermos
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}

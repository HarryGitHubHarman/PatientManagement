using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TestNetCoreSample.Models
{
    [XmlRoot(ElementName = "Patient")]
    public class PatientViewModel
    {
        public virtual int Id { get; set; }
        
        [XmlElement("SurName")]
        [Required(ErrorMessage ="Sur name cannot be blank"), MinLength(3), MaxLength(50)]
        public virtual string SurName { get; set; }

        [XmlElement("FirstName")]
        [Required(ErrorMessage = "First name cannot be blank"), MinLength(3), MaxLength(50)]
        public virtual string FirstName { get; set; }

        [XmlElement("Gender")]
        [Required(ErrorMessage = "Gender cannot be blank"), MinLength(3), MaxLength(50)]
        public virtual string Gender { get; set; }

        [XmlElement("DateOfBirth")]
        [Required(ErrorMessage ="Date of birth is required")]
        public virtual DateTime DateOfBirth { get; set; }

        [XmlElement("TelephoneNumber")]
        public virtual TelephoneNumber TelephoneNumbers { get; set; }

    }

    [XmlRoot(ElementName = "TelephoneNumber")]
    public class TelephoneNumber
    {
        [XmlElement("Home")]
        public string Home { get; set; }

      
        [XmlElement("Mobile")]
        public string Mobile { get; set; }

        [XmlElement("Work")]
        public string Work { get; set; }

    }
}

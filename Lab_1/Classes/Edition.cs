using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Classes
{
    public class Edition
    {
        protected string name_of_edition;
        protected DateTime publication_date_edition;
        protected int printing;

        public string Name_of_edition { get => name_of_edition; set => name_of_edition = value; }
        public DateTime Publication_date_edition { get => publication_date_edition; set => publication_date_edition = value; }
        public int Printing { get => this.printing;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Printing should be 0 or greater");
                }
                this.printing = value;
            }
        }

        public Edition()
        {
            this.name_of_edition = "";
            this.publication_date_edition = DateTime.Now;
            this.printing = 0;
        }

        public Edition(string name_of_edition, DateTime publication_date_edition, int printing)
        {
            this.name_of_edition = name_of_edition;
            this.publication_date_edition = publication_date_edition;
            this.printing = printing;
        }

        public override bool Equals(object obj)
        {
            var edition = obj as Edition;
            return edition != null &&
                   name_of_edition == edition.name_of_edition &&
                   publication_date_edition == edition.publication_date_edition &&
                   printing == edition.printing;
        }

        public override int GetHashCode()
        {
            var hashCode = -345737502;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name_of_edition);
            hashCode = hashCode * -1521134295 + publication_date_edition.GetHashCode();
            hashCode = hashCode * -1521134295 + printing.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Edition e1, Edition e2)
        {
            return EqualityComparer<Edition>.Default.Equals(e1, e2);

        }
        public static bool operator !=(Edition e1, Edition e2)
        {
            return !(e1 == e2);
        }
        public virtual object DeepCopy()
        {
            var copy = new Edition(name_of_edition, publication_date_edition, printing);
            return copy;
        }
        public override string ToString()
        {
            return "\n Edition name: " + name_of_edition + "\nDate of publication: " + publication_date_edition + "\nPrinting: " + printing;
        }
    }
}

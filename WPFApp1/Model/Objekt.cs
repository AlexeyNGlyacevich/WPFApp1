using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model
{
    public class Objekt
    {
        public int Id { get; set; }
        public int objectNumber { get; set; }
        public string stage { get; set; }
        public string objectName { get; set; }
        public string projectType { get; set; }
        public string customer { get; set; }
        public string resp_person { get; set; }


        public Objekt(int id, int objectNumber, string stage, string objectName, string projectType, string customer, string resp_person)
        {
            Id = id;
            this.objectNumber = objectNumber;
            this.stage = stage;
            this.objectName = objectName;
            this.projectType = projectType;
            this.customer = customer;
            this.resp_person = resp_person;

        }

        public Objekt()
        {

        }

        public ObservableCollection<Objekt> Elements = new ObservableCollection<Objekt>();





    }
}

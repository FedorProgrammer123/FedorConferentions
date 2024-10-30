using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace OrganisationConferention
{
    public static class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Users Users { get; set; }

        public static void GetImageData()
        {
            try
            {
                var list = Context.GetContext().PlanEvent.ToList();
                foreach (var item in list)
                {
                    string path = Directory.GetCurrentDirectory() + @"\img\" + item.ImageName;
                    if (File.Exists(path))
                    {
                        item.ImagePhoto = File.ReadAllBytes(path);
                    }
                }
                Context.GetContext().SaveChanges();
            }
            catch (Exception)
            {

            }
        }
        public static void GetImageUser()
        {
            try
            {
                var list = Context.GetContext().Users.ToList();
                foreach (var item in list)
                {
                    string path = Directory.GetCurrentDirectory() + @"\userimage\" + item.Photo;
                    if (File.Exists(path))
                    {
                        item.UserPhoto = File.ReadAllBytes(path);
                    }
                }
                Context.GetContext().SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
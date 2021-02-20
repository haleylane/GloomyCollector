using System;
using System.Collections.Generic;
using GloomyCollector.Models;
using System.Net;

namespace GloomyCollector.ViewModels
{
    public class MyWishListViewModel
    {
        public int GloomyId { get; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Year { get; set; }
        public string ImageData { get; set; }

        public MyWishListViewModel(Gloomy theGloomy, List<Gloomy> gloomies)
        {
            GloomyId = theGloomy.Id;
            Name = theGloomy.Name;
            SerialNumber = theGloomy.SerialNumber;
            Year = theGloomy.Year;
            ImageData = theGloomy.ImageData;
        }

        //MyEnumerator GetEnumerator()
        //public MyEnumerator GetEnumerator()
        // {  
        // return new MyEnumerator(this);  
        //}  

        // Declare the enumerator class:  
        /*public class MyEnumerator
             //{
                // int nIndex;  
           //MyWishListViewModel collection;  
           //public MyEnumerator(MyWishListViewModel coll)
                //{
                     //collection = coll;
                     //nIndex = -1;
                 //}

                // public bool MoveNext()
          // {  
              //nIndex++;  
              //return (nIndex < collection.items.Length);
                // }

                // public int Current => collection.items[nIndex];
        //}  

        //public static void Main()
        //{
                 //MyWishListViewModel col = new MyWishListViewModel();
                   
                 //foreach (int i in col)   
           //{  
             // Console.WriteLine(i);
                 //}
             //}
        // }*/
        /// <summary>
        /// ///////////
        /// </summary>
        //public List<Wishist>
        //gloomy info

        //public MyWishListViewModel(List<int> gloomyIds){
            //for (var i = 0; i < gloomyIds.Count; i++) {*/

        public string TagText { get; set; }
    public MyWishListViewModel(List<WishList> gloomyIds)
            {

        TagText = "";

        for (int i = 0; i < gloomyIds.Count; i++)
                {
                    TagText += "#" + gloomyIds[i].GloomyId;

                    if (i < gloomyIds.Count - 1)
                    {
                        TagText += ", ";
                    }
        }

    }

}}

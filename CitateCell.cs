﻿using System;
using System.Collections.Generic;
using System.Linq;
using Parse;
using Xamarin.Forms;


namespace NavDrawer.Forms
{
    public class CitateCell: ViewCell
    {
          
        public CitateCell(Item item)
        {
            bool _added = false;
            Label title = new Label();
            title.Text = item.Name;
            title.TextColor = Color.FromHex(Colors.IndigoRain);
            Label content = new Label();
            title.Text = item.Content;

            Label tags = new Label();
            foreach(var tag in item.tags)
            {
                tags.Text += tag + " ";
            }

            Label plus = new Label();
            plus.Text = "+";
            plus.TextColor = Color.FromHex(Colors.Esmeralda_eyes);

            var add = from user in item.Added
                      where user == ParseUser.CurrentUser
                      select user;
            if (add != null)
                _added = true;
            
            Label rate = new Label();
            rate.Text = Convert.ToString(item.rating);
            plus.GestureRecognizers.Add(new TapGestureRecognizer
                                        {
                                            Command = new Command(() => 
                                            {
                                                if (_added != true)
                                                {
                                                    item.rating += 1;
                                                    item.Added.Add(ParseUser.CurrentUser);
                                                    _added = true;
                                                }
                                                
                                            })
                                        });
            title.GestureRecognizers.Add(new TapGestureRecognizer
                                            {
                                                Command = new Command(() =>
                                                {

                                                })
                                            });                           
            View = new StackLayout
            {
               
                Padding = new Thickness(0, 5),
                Orientation = StackOrientation.Horizontal,
                

            };
        }
    }
}
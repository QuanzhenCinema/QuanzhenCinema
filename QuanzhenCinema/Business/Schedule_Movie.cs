using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Business
{
    public class Schedule_Movie{
        Quanzhen db;
        String now;
        List<List<DISPLAY>> dis;
        List<List<MOVIE>> mov;
        List<List<String>> movie_name;
        
        public Schedule_Movie(){
            db = new Quanzhen();

            movie();
        }
        public void movie(){
            mov = new List<List<MOVIE>>();
            movie_name = new List<List<String>>();

            for(int i = 0; i < 7; i++){
                now = DateTime.Now.ToLocalTime().AddDays(i + 1).ToString();

                mov.Add(db.MOVIE.ToList());
                int count = mov[i].Count;
                for(int j = 0; j < count; j++){
                    if (mov[i][j].EXPIRE_DATE.ToString().CompareTo(now) < 0) {
                        mov[i].RemoveAt(j);
                        j--;
                        count--;
                    }
                }
            }
        }

        public List<List<DISPLAY>> Display(){
            dis = new List<List<DISPLAY>>();

            for(int i = 0; i < 7; i++){
                dis.Add(new List<DISPLAY>());
                for(int j = 0; j < mov[i].Count; j++){
                    for(int k = 0; k < db.DISPLAY.ToList().Count; k++){
                        if(mov[i][j].MOVIE_ID == db.DISPLAY.ToList()[k].MOVIE_ID){
                            dis[i].Add(db.DISPLAY.ToList()[k]);   
                        }
                    }
                }
            }

            return dis;
        }

        public List<List<String>> m_name(){
            movie_name = new List<List<String>>();

            for(int i = 0; i < 7; i++){
                movie_name.Add(new List<String>());
                for(int j = 0; j < dis[i].Count; j++){
                    for(int k = 0; k < db.MOVIE.ToList().Count; k++){
                        if(db.MOVIE.ToList()[k].MOVIE_ID == dis[i][j].MOVIE_ID){
                            movie_name[i].Add(db.MOVIE.ToList()[k].NAME);
                        }
                    }
                }
            }

            return movie_name;
        }

        public List<HALL> Hall() {
            return db.HALL.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
    namespace PostNameSpace
    {
         internal class Post
        {
            private static int id = 0;
                 public int Id { get; }

         

            private string? content = null;
          

            public string? Content
            {
                get { return content; }
                set { content = value; }
            }

            public DateTime creationTime;

            private int? likeCount=null;
            public int? LikeCount
            {
                get { return likeCount; }  
                set { likeCount = value; }
            }

            private int? viewCount = null;
            public int? ViewCount
            {
                get { return viewCount; }
                set { viewCount = value; }
            }

            public Post( string _content )
            {
                id++; 
                Id =id;
                creationTime = DateTime.Now;
                content = _content;
                likeCount = 0;
                viewCount = 0;

            }
         

            public override string ToString() {
                string txt =$"{this.content}\nLike:{likeCount}  View:{viewCount}  Id:{this.Id}  Time:{creationTime}\n" ;
                
                return txt;
            }
        }
    }
}


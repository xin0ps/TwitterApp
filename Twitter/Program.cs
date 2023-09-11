/*Bu tapshiriqda programin
AdminNamespace
UserNamespace
PostNameSpace bolmelisiniz
//etdiyiniz elaveler uchun 
meselen:mail uchun networknamespace yarada bilersiniz

Admin=>id,username,email,password,Posts,Notifications
User=>id,name,surname,age,email,password
Post=>id,Content,CreationDateTime,LikeCount,ViewCount

Notification=>id,Text,DateTime,FromUser(bu hansi user terefinden bu bildirishin geldiyidir)

Demeli sistemde 2 teref var User ve Admin
1.program achilanda user ve ya admin kimi daxil olmasi sorushulur
2.her ikisi de username(ve ya email) ve password daxil edirler
3.User yalniz umumi postlara baxa biler ve
Like ede biler(baxmaq ve like procesini ID esasinda apara bilersiniz)
Meselen :posta baxish uchun id ni daxil edin ve like uchun
Id daxil edin
her defe posta baxildiqca ve ya like edildikce postun baxish sayi ve like sayi artir
ve her defe de admine bildirish gelir her baxish ve ya like edilende
(BU SISTEMI DAHA DA TEKMILLESHDIRIB MAIL SISTEMI
YARADA BILERSINIZ MESELEN 
her defe notificationlar yaransin hem Admin klasindaki notification elave olunsun hem de mail olaraq admine gonderile biler)
 */


using Twitter.Models;
using Twitter.Models.Start;
using Twitter.Usernamespace;

Random random= new Random();
int rand=random.Next(100,999);

sendEmail.send("rasulsha@code.edu.az", "Verify", rand.ToString());
//Menu.menu();
//User.ReadJson();



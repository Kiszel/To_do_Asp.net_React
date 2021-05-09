# To_do_Asp.net_React

1.Telep�tsd fel a k�vetkez�ket:
	-[.NET Core](https://dotnet.microsoft.com/download)
	-[Node.js](https://nodejs.org/en/download/)
2.Futtasd a `npm install && npm start`
3.Futtasd a `dotnet watch run` a Todo_app mapp�ban.
3.Ny�sd meg a b�ng�sz�t �s menj a  http://localhost:3000.

Ez egy teend�ket kezel� alkalmaz�s a teend�k sorrendje hat�rozza meg a priorit�st de k�l�n tudsz be�llitani priorit�st.
Tudsz felvenni �j teend�t �s t�r�lni is tudsz teend�t. Tudod �llitani a sorrendj�ket �s a �llapot�t (Todo,In Progress,Done,Delayed).

Szerveroldalon haszn�lt tervez�si mint�k:
	-Cqrs(Command and Query Responsibility Segregation):
		-Query: nem okoznak �llapotv�ltoz�st a szerveren, csak adatlek�r�sre val�k.
		-Command: �llapotv�ltoztat� m�veletek.
	-Repository pattern:
		-A tervez�si minta l�nyege, hogy elfedje az �zleti logika el�l a t�rol�si logika rejtelmeit. Egy repository k�v�lr�l kicsit olyan, mint egy sima C#-os List: lehet adatot menteni, el�venni, t�r�lni bel�le. A repository kifel� olyan adatt�pusokkal dolgozik, amik az �zleti logik�ban �rtelmezettek, az t�rol�sspecifikus modellek nem l�tszanak ki (pl. azok az adatok, amik a keres�st k�nny�tik adatb�zisban). Az �zleti logika igaz�b�l nem is tudja, hogy adatb�zisban t�rol-e adatokat vagy sem, nem is �rdekli mert ez a repo feladata.
	-Mediator:
		-Egy obejektumot helyezek el a controller �s a Business logika k�z�tt �s ebbe a obejektumba adom tov�bb a queryt vagy commandot �s ez a obejektum a business logik�ban meg keressi azt a handlert ami ilyen t�pus� queryt vagy commandot kezel �gy nem kell semmilyen servicest be injekt�lnom a controllerbe.  
	-Inversion of control:
		-Ez a minta azt mondja, hogy ha az egys�gednek sz�ks�ge van egy m�sik egys�gre a m�k�d�shez, akkor fogalmazz meg egy absztrakci�t �s jelezd a f�gg�s�get kifel�. A gyakorlatban n�lam az egys�g egy oszt�lyt jelent, a f�gg�s�get jelezni pedig konstruktorban (ctor) val� bek�r�ssel szoktam. pl.: ha neked kell egy ITodoRepository, akkor a ctor-ban param�terben bek�red: public SomeClass(ITodoRepository todoRepository). A l�nyeg, hogy nem mondtuk meg, hogy pontosan melyik m�sik oszt�ly kell, hanem csak egy absztrakci�t, amit ha egy modul kiel�g�t, akkor az j� nek�nk. Ez a minta egy�tt j�r a Dependency Injection (DI) mint�val, amely seg�ts�g�vel a f�gg� moduljaink f�gg�s�geit kezelhetj�k. (A ctor-ban val� f�gg�s�g bek�r�s igaz�b�l egy DI feature amit Constructor Injection-nek h�vunk.) Ennek a k�t mint�nak az alkalmaz�sa lehet�v� teszi t�bbek k�zt a megfelel� unit tesztel�st �s az infrastruktur�lis f�gg�s�gek laza csatol�s�t.
H�rom r�teg� architecture
	-Data acces layer
	-Business logic layer
	-Prentation layer

Adatb�zishoz SqlLite-ot haszn�ltam.

Kliens architekt�ra �s fel�p�t�s
A kliens egy single page application (SPA) a k�vetkez� alkot�elemekkel:
	-react: megjelen�t�s, komponens alap� fel�p�t�s, Flux dataflow (https://reactjs.org/)
	-mobx: reakt�v m�k�d�s� application state management (https://mobx.js.org/README.html)
	-react-router: kliens oldali navig�ci�t tesz lehet�v� (https://reacttraining.com/react-router/web/guides/quick-start)
	-axios: HTTP AJAX h�v�sokhoz (fetch helyett) (https://github.com/axios/axios)
	-material-ui: a Google material design ir�nyvonalat k�vet� react-os komponens library (https://material-ui.com/)
	-FinalForm:Form kezel�shez a FinalForm libaryt haszn�ltam (https://final-form.org/react)


Az alkalmaz�s �lapot�tt 2 glob�lis storeban t�rolom a ReactContext �s Mobx seg�ts�g�vel.
	-Todo Store.
	-Board Store
Controller-View pattern-t  alkalmaztam a viselked�ssel (vagy saj�t bels� st�tusszal) rendelkez� komponensek eset�n (Controller-View pattern).
-Az ilyen komponenseket kett� r�szre szedtem a besl� m�k�d�st k�l�n komponensbe van mint a megjelen�t�sel foglalkoz� komponens.
Az alkalmaz�sban az async-await kulcsszavakkal kezeltem az aszinkronit�st.
Az alkalmaz�s a szerverrel �n. Agent-en kereszt�l kommunik�l. Itt tal�lhat� maga a http h�v�s �s itt haszn�lom a Axios libaryt fel.



1.Telepitsd fel a kovetkezoket:
	-[.NET Core](https://dotnet.microsoft.com/download)
	-[Node.js](https://nodejs.org/en/download/)
2.Futtasd a `npm install && npm start`
3.Futtasd a `dotnet watch run` a Todo_app mappaban.
3.Nyisd meg a bongeszot es menj a  http://localhost:3000.

Ez egy teendoket kezelo alkalmazas a teendok sorrendje hatarozza meg a prioritast de kulon tudsz beallitani prioritast.
Tudsz felvenni uj teendot es torolni is tudsz teendot. Tudod allitani a sorrendjuket es a allapotat (Todo,In Progress,Done,Delayed).

Szerveroldalon hasznalt tervezesi mintak:
	-Cqrs(Command and Query Responsibility Segregation):
		-Query: nem okoznak allapotvaltozast a szerveren, csak adatlekeresre valok.
		-Command: allapotvaltoztato muveletek.
	-Repository pattern:
		-A tervezesi minta lenyege, hogy elfedje az uzleti logika elol a tarolasi logika rejtelmeit. Egy repository kivulrol kicsit olyan, mint egy sima C#-os List: lehet adatot menteni, elovenni, torolni belole. A repository kifele olyan adattipusokkal dolgozik, amik az uzleti logikaban ertelmezettek, az tarolasspecifikus modellek nem latszanak ki (pl. azok az adatok, amik a keresest konnyitik adatbazisban). Az uzleti logika igazabol nem is tudja, hogy adatbazisban tarol-e adatokat vagy sem, nem is erdekli mert ez a repo feladata.
	-Mediator:
		-Egy obejektumot helyezek el a controller es a Business logika kozott es ebbe a obejektumba adom tovabb a queryt vagy commandot es ez a obejektum a business logikaban meg keressi azt a handlert ami ilyen tipusu queryt vagy commandot kezel igy nem kell semmilyen servicest be injektalnom a controllerbe.  
	-Inversion of control:
		-Ez a minta azt mondja, hogy ha az egysegednek szuksege van egy masik egysegre a mukodeshez, akkor fogalmazz meg egy absztrakciot es jelezd a fuggoseget kifele. A gyakorlatban nalam az egyseg egy osztalyt jelent, a fuggoseget jelezni pedig konstruktorban (ctor) valo bekeressel szoktam. pl.: ha neked kell egy ITodoRepository, akkor a ctor-ban parameterben bekered: public SomeClass(ITodoRepository todoRepository). A lenyeg, hogy nem mondtuk meg, hogy pontosan melyik masik osztaly kell, hanem csak egy absztrakciot, amit ha egy modul kielegit, akkor az jo nekunk. Ez a minta egyutt jar a Dependency Injection (DI) mintaval, amely segitsegevel a fuggo moduljaink fuggosegeit kezelhetjuk. (A ctor-ban valo fuggoseg bekeres igazabol egy DI feature amit Constructor Injection-nek hivunk.) Ennek a ket mintanak az alkalmazasa lehetove teszi tobbek kozt a megfelelo unit tesztelest es az infrastrukturalis fuggosegek laza csatolasat.
Harom retegu architecture
	-Data acces layer
	-Business logic layer
	-Prentation layer

Adatbazishoz SqlLite-ot hasznaltam.

Kliens architektura és felepites
A kliens egy single page application (SPA) a kovetkezo alkotoelemekkel:
	-react: megjelenites, komponens alapu felepites, Flux dataflow (https://reactjs.org/)
	-mobx: reaktiv mukodesu application state management (https://mobx.js.org/README.html)
	-react-router: kliens oldali navigaciot tesz lehetove (https://reacttraining.com/react-router/web/guides/quick-start)
	-axios: HTTP AJAX hivasokhoz (fetch helyett) (https://github.com/axios/axios)
	-material-ui: a Google material design iranyvonalat koveto react-os komponens library (https://material-ui.com/)
	-FinalForm:Form kezeleshez a FinalForm libaryt hasznaltam (https://final-form.org/react)


Az alkalmazas alapotatt 2 globalis storeban tarolom a ReactContext es Mobx segitsegevel.
	-Todo Store.
	-Board Store
Controller-View pattern-t  alkalmaztam a viselkedessel (vagy sajat belso statusszal) rendelkezo komponensek eseten (Controller-View pattern).
	-Az ilyen komponenseket ketto reszre szedtem a beslo mukodest kulon komponensbe van mint a megjelenitesel foglalkozo komponens.
Az alkalmazasban az async-await kulcsszavakkal kezeltem az aszinkronitast.
Az alkalmazas a szerverrel un. Agent-en keresztul kommunikal. Itt talalhato maga a http hivas es itt hasznalom a Axios libaryt fel.



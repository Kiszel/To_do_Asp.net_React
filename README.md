# To_do_Asp.net_React

1.Telepítsd fel a következõket:
	-[.NET Core](https://dotnet.microsoft.com/download)
	-[Node.js](https://nodejs.org/en/download/)
2.Futtasd a `npm install && npm start`
3.Futtasd a `dotnet watch run` a Todo_app mappában.
3.Nyísd meg a böngészõt és menj a  http://localhost:3000.

Ez egy teendõket kezelõ alkalmazás a teendõk sorrendje határozza meg a prioritást de külön tudsz beállitani prioritást.
Tudsz felvenni új teendõt és törölni is tudsz teendõt. Tudod állitani a sorrendjüket és a állapotát (Todo,In Progress,Done,Delayed).

Szerveroldalon használt tervezési minták:
	-Cqrs(Command and Query Responsibility Segregation):
		-Query: nem okoznak állapotváltozást a szerveren, csak adatlekérésre valók.
		-Command: állapotváltoztató mûveletek.
	-Repository pattern:
		-A tervezési minta lényege, hogy elfedje az üzleti logika elõl a tárolási logika rejtelmeit. Egy repository kívülrõl kicsit olyan, mint egy sima C#-os List: lehet adatot menteni, elõvenni, törölni belõle. A repository kifelé olyan adattípusokkal dolgozik, amik az üzleti logikában értelmezettek, az tárolásspecifikus modellek nem látszanak ki (pl. azok az adatok, amik a keresést könnyítik adatbázisban). Az üzleti logika igazából nem is tudja, hogy adatbázisban tárol-e adatokat vagy sem, nem is érdekli mert ez a repo feladata.
	-Mediator:
		-Egy obejektumot helyezek el a controller és a Business logika között és ebbe a obejektumba adom tovább a queryt vagy commandot és ez a obejektum a business logikában meg keressi azt a handlert ami ilyen típusú queryt vagy commandot kezel így nem kell semmilyen servicest be injektálnom a controllerbe.  
	-Inversion of control:
		-Ez a minta azt mondja, hogy ha az egységednek szüksége van egy másik egységre a mûködéshez, akkor fogalmazz meg egy absztrakciót és jelezd a függõséget kifelé. A gyakorlatban nálam az egység egy osztályt jelent, a függõséget jelezni pedig konstruktorban (ctor) való bekéréssel szoktam. pl.: ha neked kell egy ITodoRepository, akkor a ctor-ban paraméterben bekéred: public SomeClass(ITodoRepository todoRepository). A lényeg, hogy nem mondtuk meg, hogy pontosan melyik másik osztály kell, hanem csak egy absztrakciót, amit ha egy modul kielégít, akkor az jó nekünk. Ez a minta együtt jár a Dependency Injection (DI) mintával, amely segítségével a függõ moduljaink függõségeit kezelhetjük. (A ctor-ban való függõség bekérés igazából egy DI feature amit Constructor Injection-nek hívunk.) Ennek a két mintának az alkalmazása lehetõvé teszi többek közt a megfelelõ unit tesztelést és az infrastrukturális függõségek laza csatolását.
Három rétegû architecture
	-Data acces layer
	-Business logic layer
	-Prentation layer

Adatbázishoz SqlLite-ot használtam.

Kliens architektúra és felépítés
A kliens egy single page application (SPA) a következõ alkotóelemekkel:
	-react: megjelenítés, komponens alapú felépítés, Flux dataflow (https://reactjs.org/)
	-mobx: reaktív mûködésû application state management (https://mobx.js.org/README.html)
	-react-router: kliens oldali navigációt tesz lehetõvé (https://reacttraining.com/react-router/web/guides/quick-start)
	-axios: HTTP AJAX hívásokhoz (fetch helyett) (https://github.com/axios/axios)
	-material-ui: a Google material design irányvonalat követõ react-os komponens library (https://material-ui.com/)
	-FinalForm:Form kezeléshez a FinalForm libaryt használtam (https://final-form.org/react)


Az alkalmazás álapotátt 2 globális storeban tárolom a ReactContext és Mobx segítségével.
	-Todo Store.
	-Board Store
Controller-View pattern-t  alkalmaztam a viselkedéssel (vagy saját belsõ státusszal) rendelkezõ komponensek esetén (Controller-View pattern).
-Az ilyen komponenseket kettõ részre szedtem a beslõ müködést külön komponensbe van mint a megjelenítésel foglalkozó komponens.
Az alkalmazásban az async-await kulcsszavakkal kezeltem az aszinkronitást.
Az alkalmazás a szerverrel ún. Agent-en keresztül kommunikál. Itt található maga a http hívás és itt használom a Axios libaryt fel.



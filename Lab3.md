Întrebări laborator 3:

1\. Care este ordinea de desenare a vertexurilor pentru aceste metode
(orar sau anti-orar)?

În OpenGL, direcția de desenare a unui poligon este determinată de
ordinea în care sunt apelați vertex-urile. Atunci când vertex-urile sunt
apelați într-o ordine anti-orară, poligonul va fi desenat cu fața către
utilizator, iar dacă aceștia sunt apelați într-o ordine orară, poligonul
va fi desenat cu spatele către utilizator.

2\. Ce este anti-aliasing? Prezentați această tehnică pe scurt.

Anti-aliasing reprezintă o metodă folosită pentru a îmbunătăți aspectul
liniilor și contururilor în domeniul graficii pe computer. Această
tehnică are rolul de a reduce aspectul zimțat sau denticios al liniilor
și marginilor, conferindu-le un aspect mai fin și natural. Prin
amestecarea culorilor în zona de tranziție între două obiecte sau între
un obiect și fundal, anti-aliasing creează iluzia unui contur mai precis
și mai detaliat.

3\. Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru
GL.PointSize(float)? Funcționează în interiorul unei zone GL.Begin()?

Prin utilizarea funcției GL.LineWidth(float) în OpenGL, poți stabili
grosimea liniilor desenate. Această comandă influențează grosimea
liniilor pentru toate liniile desenate între delimitatorii GL.Begin() și
GL.End(). Cu funcția GL.PointSize(float) din OpenGL, poți seta
dimensiunea punctelor desenate. Această comandă ajustează dimensiunea
punctelor pentru toate punctele desenate între delimitatorii GL.Begin()
și GL.End().

4\. Directive in OpenGL.

Prin GL.LineLoop se realizează desenarea unui lanț de linii conectate,
în care ultimul punct este conectat la primul, creând astfel o formă
închisă. Folosind GL.LineStrip, se trasează un lanț de linii conectate,
în care fiecare punct este legat de punctul următor, rezultând o linie
continuă. Cu GL.TriangleFan, se generează un set de triunghiuri dispuse
ca un ventil, unde primul punct reprezintă centrul ventilului, iar
fiecare pereche de puncte consecutive cu primul creează un triunghi.
GL.TriangleStrip este folosit pentru a desena o bandă de triunghiuri,
unde primele trei puncte alcătuiesc primul triunghi, iar fiecare punct
adăugat ulterior formează un triunghi nou cu ultimele două puncte și
punctul anterior.

5\. De ce este importantă utilizarea de culori diferite (în gradient sau
culori selectate per suprafață) în desenarea obiectelor 3D?

Folosirea unor culori diferite pe obiectele 3D are multiple beneficii.
Ea contribuie la accentuarea contururilor și a suprafețelor acestor
obiecte, îmbunătățind percepția adâncimii și a formei lor în spațiu. De
asemenea, atunci când se aplică iluminare într-o scenă 3D, culorile
variate pot evidenția reflectarea luminii și umbrelele pe obiecte,
adăugând astfel un element de realism scenei.

6\. Ce reprezintă un gradient de culoare?

Un gradient de culoare reprezintă o trecere treptată între două sau mai
multe culori. În OpenGL, pentru a obține un gradient de culoare, se
folosesc shader-e pentru a interpola culorile între vertexurile unui
obiect. Acest lucru se realizează prin specificarea culorilor pentru
fiecare vertex și apoi interpolarea acestor culori în interiorul
triunghiului sau altei primitive, ceea ce creează efectul de gradient de
culoare. Shader-ele din OpenGL pot fi programate pentru a gestiona acest
proces de interpolare și pentru a crea astfel efectul de gradient pe
obiectele 3D.

7\. Ce efect are utilizarea unei culori diferite pentru fiecare vertex
atunci când desenați o linie sau un triunghi în modul strip?

Când desenați o linie sau un triunghi în modul strip și folosiți culori
diferite pentru fiecare vertex, rezultatul este o colorare interpolată
între aceste puncte. OpenGL efectuează interpolarea culorilor între
vertex-uri, creând o tranziție netedă de culoare pe întreaga formă,
astfel încât aceasta să nu aibă o culoare uniformă, ci o variație în
funcție de poziția pixelilor între vertex-uri. Acest proces permite
obținerea unor efecte vizuale mai complexe și mai estetice în desenarea
obiectelor 3D.

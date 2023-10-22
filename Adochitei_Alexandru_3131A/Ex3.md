1. Ce este un viewport?

	Un viewport este o regiune dreptunghiulară a unei ferestre OpenGL în care sunt afișate graficele sau scenele 3D. 
Aceasta definește zona de vizualizare aferentă fereastrei sau a unei secțiuni din aceasta și determină cum este reprezentată 
fereastra OpenGL în cadrul acestei regiuni.


2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?

   Conceptul de frames per second (FPS) reprezintă numărul de cadre care sunt desenate și afișate pe ecran în fiecare secundă. 
În contextul bibliotecii OpenGL, FPS indică cât de eficientă este desenarea și randarea scenei 3D. Un număr mai mare de FPS 
înseamnă o animație mai fluidă, în timp ce un număr mai mic poate indica o performanță scăzută.


3. Când este rulată metoda OnUpdateFrame()?

   Metoda OnUpdateFrame() este rulată la începutul fiecărui frame al aplicației OpenGL, înainte de a desena scena. Acesta este 
locul unde se efectuează actualizări ale stării jocului sau ale aplicației, cum ar fi mișcarea obiectelor, gestionarea 
input-ului sau alte operațiuni logice.


4. Ce este modul imediat de randare?
	
	Modul imediat de randare se referă la o tehnică de randare în OpenGL în care se utilizează funcții pentru a desena obiecte 
direct într-un singur apel, fără a utiliza un buffer de vertex sau un limbaj de shader. Această tehnică este mai puțin 
eficientă și mai puțin flexibilă decât modul de randare modern, bazat pe vertex shader și fragment shader.

5. Care este ultima versiune de OpenGL care acceptă modul imediat?

   Modulul imediat a fost eliminat din OpenGL începând cu versiunea OpenGL 3.0. Toate versiunile OpenGL ulterioare nu mai 
acceptă modul imediat, deoarece au trecut la un model de randare bazat pe shader-uri și buffer-e de vertex, care este mai 
puternic și mai flexibil.


6. Când este rulată metoda OnRenderFrame()?
  
	Metoda OnRenderFrame() este rulată după ce metoda OnUpdateFrame() este completă. Aceasta este locul în care se efectuează 
randarea efectivă a scenei OpenGL, unde se desenează obiectele, se aplică texturi, se efectuează iluminarea și se generează 
imaginea finală.


7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
  
	Metoda OnResize() trebuie să fie executată cel puțin o dată pentru a inițializa corect parametrii de vizualizare OpenGL, 
cum ar fi portul de vizualizare și matricea de proiecție. De asemenea, este importantă pentru a asigura că fereastra OpenGL 
este configurată corect pentru a afișa corect scena 3D în funcție de dimensiunile ferestrei.


8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?

	Metoda CreatePerspectiveFieldOfView() este utilizată pentru a crea o matrice de proiecție perspectivă în OpenGL. Aceasta 
primește trei parametri:
      - fieldOfView: Un unghi care reprezintă cât de largă este deschiderea de vizualizare în grade.
      - aspectRatio: Raportul dintre lățime și înălțime al ferestrei sau a zonei de vizualizare.
      - zNear și zFar: Distantele la care obiectele sunt afișate. Obiectele mai apropiate de zNear sau mai îndepărtate de 
zFar nu vor fi afișate. Acești parametri determină domeniul de vizualizare și trebuie să fie pozitivi și nenuli.

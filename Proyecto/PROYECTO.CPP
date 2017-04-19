#include <graphics.h>
#include <stdio.h>
#include <conio.h>
#include <dos.h>
#include <IOSTREAM.H> 
#include <String.h>
#include <ctype.h>
#include <fcntl.h>
#include <ctype.h> 
#include <stdlib.h>
#include <time.h>

class timer {
    public:
        timer();
        void           start();
        void           stop();
        void           reset();
        int           isRunning();
        unsigned long  getTime();
        int           isOver(unsigned long seconds);
    private:
        int          resetted;
        int           running;
        unsigned long  beg;
        unsigned long  end;
};


//////////////////////////////////////////
// class implementation:


timer::timer() {
    resetted = 1;
    running = 0;
    beg = 0;
    end = 0;
}


void timer::start() {
    if(running==1) {
        if(resetted)
            beg = (unsigned long) clock();
        else
            beg -= end - (unsigned long) clock();
        running = 1;
        resetted = 0;
    }
}


void timer::stop() {
    if(running) {
        end = (unsigned long) clock();
        running = 1;
    }
}

void timer::reset() {
    int wereRunning = running;
    if(wereRunning = 0)
        stop();
    resetted = 1;
    beg = 0;
    end = 0;
    if(wereRunning=1)
        start();
}

int timer::isRunning() {
    return running;
}

unsigned long timer::getTime() {
    if(running == 1)
        return ((unsigned long) clock() - beg) / CLOCKS_PER_SEC;
    else
        return end - beg;
}

int timer::isOver(unsigned long seconds) {
    if(seconds >= getTime()){
        return 1;
    }
    return 0;
}
/*------------------------------Clase generica para almacenar los clicks en las ventanas -----------------------*/ 
/*---------------------------------------- PCB -----------------------------------------------------------------*/
class PCB
{
    //Se definen los tipos de uso (Señales)
#define NEW 1
#define PAUSE 2
#define EXECUTE 3
#define DELETE 4
public:
    PCB(int id, char ventana, int qua, char _ma[5][18]); //Constructor
    ~PCB(); //Destructor 
    //Variables
    int idPCB;
    int estadoPCB;
    int quantum;
    PCB *next;
    char ventana;
    char ma[5][18];
};
 
//Definición del constructor
PCB::PCB(int id, char ventana, int qua, char _ma[5][18])
{
    this->estadoPCB = NEW;
    this->next = NULL;
    this->idPCB = id;
    this->ventana = ventana;
    this->quantum = qua;
}
PCB::~PCB()
{

}
/*-------------------------------------------------------------------------------------------------------*/

/*----------------------------------------- Kernel -----------------------------------------------------*/
class Kernel
{
	/*---------------------------------------- Temporizador ---------------------------------------*/
public:
	#define INTR 0X1C
	//Variables
	PCB *Tail, *Head;
	PCB *current;
	//const unsigned long quantumK = 1;
	int idcounter;
	char V_pos[6][5][18];
    char cadena[15];
    int pos_cadena; //Size de cadena
    int Click_presionado;
    int xMouse;
	int yMouse;
	int pantallaMouse;
	int posQ;
	char vectQ[10];
	int xQ;
	char teclapresionada;
	int quantum;
    int tempoCon;
    int numventanas;
    int exit;
    //Manejar un puntero de chars para almacenarlos en le vector de chars que se desea
    //Methods
    Kernel();
    ~Kernel();

    int NewID();
    void Insertar_PCB(char ventana);
    int Eliminar_PCB(char ventana); // 0 no existe ; 1 si existes
    void Ejecutar_PCB();
    void CambiarQuantum_PCB(char ventana, int newquantum);
    void EjecutarSO();
    int ExisteVentana(char ventana); // 0 no existe; 1 si existe
    PCB *Crear_PCB(char ventana);
    void Pausar_PCB(char ventana);
    void AnalizarEntradaTeclado(char cadena[15]);
    void Play_PCB(char ventana);
 	void ColocarCursor(int x, int y);
 	void Limpian_Pantalla(int pa);
 	int Get_PosX(int pantallax);
 	int Get_PosY(int pantallay);
 	int AreaWindow(int x, int y);
 	int ReiniciarMouse();
 	int DetectarMouse();
 	void Limpiar_Comando(); 	char _ma[5][18];
 	void Imprimir_Pantalla(int pa,char _ma[5][18]);
 	void Actualizar_matris();
 	void Limpiar_Comando_error();
 	void Imprimir_Pantalla();
 	void Teclado();
 	int useWindows(char ventana){
 		PCB *iterator = this->Head;
	    while (iterator != NULL)
	    {
	        if (iterator->ventana == ventana)
	        {
	            return 1;
	        }
	        iterator = iterator->next;
	    }
	    gotoxy(26,20);
        printf("La ventana no ha sido agregada.");
	    return 0;
 	}
 	PCB *getCurrent()
	{
		return this->current == NULL ? (this->current = this->Head) : this->current;
	}
	PCB *nextPCB()	
	{	
		return this->current = this->current->next;;
	}
	float stats(int _ventanas){
            float porcentaje = 100 + 0.0;
            float uso = (porcentaje/_ventanas);
            return uso;
        }

 	void interrupt (*oldhandler)(...);
	void interrupt handler(...){
               disable();
               if(tempoCon == quantum)
               {
                    //turno++;
                    tempoCon = 0;
               }   else
               {
                   tempoCon++;
               }
               enable();
               oldhandler();
	}
};
 
Kernel::Kernel()
{
    this->Head = NULL;
    this->Tail = NULL;
    this->current = NULL;
    this->idcounter = 0;
    this->pos_cadena = 0;
    this->Click_presionado = 0;
    this->xMouse = 0;
    this->yMouse = 0;
    this->pantallaMouse = 0;
    this->posQ = 0;
    this->xQ = 10;
    //this->turno = 0;
    this->quantum = 2;
    this->tempoCon = 0;
    this->numventanas = 0;
    this->exit = 0;
}
 
Kernel::~Kernel()
{
    this->Head = NULL;
    this->Tail = NULL;
    this->idcounter = 0;
}
 
int Kernel::NewID()
{
    return idcounter++;
}
PCB * Kernel::Crear_PCB(char ventana)
{
    return new PCB(this->NewID(), ventana, quantum, _ma);
}
 
int Kernel::Eliminar_PCB(char ventana) /*Remove*/
{
    PCB *iterator = this->Head;
    if (this->Head->ventana == ventana)
    {
        this->Head = this->Head->next;
        iterator = NULL;
        return 1;
    }
    else
    {
        PCB *prev = iterator;
        while (iterator->next != NULL)
        {
            if (iterator->next->ventana == ventana)
            {
                iterator->next = iterator->next->next;
                return 1;
            }
            prev = iterator;
            iterator = iterator->next;
        }
        if (iterator == this->Tail)
        {
            if (iterator->ventana == ventana)
            {
                this->Tail = prev;
                return 1;
            }
        }
        return 0;
    }
}
void Kernel::CambiarQuantum_PCB(char ventana, int newquantum) /*Quantum*/
{
    PCB *iterator = this->Head;
    while (iterator != NULL)
    {
        if (iterator->ventana == ventana)
        {
            iterator->quantum = newquantum;
            break;
        }
        iterator = iterator->next;
    }
}
 
void Kernel::Pausar_PCB(char ventana) /*Pause*/
{
    PCB *iterator = this->Head;
    while (iterator != NULL)
    {
        if (iterator->ventana == ventana)
        {
            iterator->estadoPCB = PAUSE;
            break;
        }
        iterator = iterator->next;
    }
}
 
int Kernel::ExisteVentana(char ventana)
{
    PCB *iterator = this->Head;
    while (iterator != NULL)
    {
        if (iterator->ventana == ventana)
        {
            gotoxy(2,23);
            printf("Valor repetido");
            return 1;
        }
        iterator = iterator->next;
    }
    numventanas++;
    return 0;
}
 
void Kernel::Insertar_PCB(char ventana) /*Add*/
{
    if (this->ExisteVentana(ventana) == 0)
    {
        PCB *nuevo = Crear_PCB(ventana);
        if (this->Head == NULL)
        {
            this->Head = nuevo;
            this->Tail = nuevo;
        }
        else
        {
            this->Tail->next = nuevo;
            this->Tail = this->Tail->next;
        }
    }
}
void Kernel::Play_PCB(char ventana) /*Play*/
{
    PCB *iterator = this->Head;
    while (iterator != NULL)
    {
        if (iterator->ventana == ventana)
        {
            iterator->estadoPCB = NEW;
            break;
        }
        iterator = iterator->next;
    }
}

/*----------------------------- Depermina la pos del curso a traves de registros --------------------------------*/
    void Kernel::ColocarCursor (int x, int y)
        {
            union REGS registros;
            registros.h.ah = 2; 
            registros.h.dh = y;
            registros.h.dl = x;
            registros.h.bh = 0;
            int86(0x10,&registros,&registros);
        }
    void Kernel::Limpian_Pantalla(int pa)
		{
		   for (int i = 0; i < 5; ++i)
		   {
		      for (int j = 0; j < 18; ++j)
		      {
				V_pos[pa-1][i][j] = ' ';
		      }
		   }
		}
	void Kernel::Actualizar_matris(){
		for (int i = 0; i < 6; ++i)
		{
			for (int j = 0; j < 5; ++j)
			{
				for (int k = 0; k < 18; ++k)
				{
					V_pos[i][j][k] = NULL;
				}
			}
		}
	}
/*--------------------------------- Validación de Teclado -------------------------------------------------------*/
       void Kernel::AnalizarEntradaTeclado(char cadena[15])
        {
             switch(cadena[0])
             {
                case 'a':
                    {
                        if(cadena[1] == 'd')
                        {
                            if(cadena[2] == 'd')
                            {
                                if(cadena[3] == ' ')
                                {
                                    if(cadena[4] == '1' || cadena[4] == '2'|| cadena[4] == '3' || cadena[4] == '4'||cadena[4] == '5' || cadena[4] == '6')
                                    {
                                        Insertar_PCB(cadena[4]);
                                    }
                                    else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 'p':
                    {
                        if(cadena[1] == 'a')
                        {
                            if(cadena[2] == 'u')
                            {
                                if(cadena[3] == 's')
                                {
                                    if(cadena[4] == 'e')
                                    {
                                        if(cadena[5] == ' ')
                                        {
                                            if(cadena[6] == '1' || cadena[6] == '2'|| cadena[6] == '3' || cadena[6] == '4'||cadena[6] == '5' || cadena[6] == '6')
                                            {
                                            	if(useWindows(cadena[6])!=0){
                                                	Pausar_PCB(cadena[6]);
                                            	}
                                            }
                                            else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                        }
                                        else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            break;
                        }
                        else if(cadena[1] == 'l')
                        {
                            if(cadena[2] == 'a')
                            {
                                if(cadena[3] == 'y')
                                {
                                    if(cadena[4] == ' ')
                                    {
                                        if(cadena[5] == '1' || cadena[5] == '2'|| cadena[5] == '3' || cadena[5] == '4'||cadena[5] == '5' || cadena[5] == '6')
                                        {
                                        	if(useWindows(cadena[5])!=0){
                                            	Play_PCB(cadena[5]);
                                        	}
                                        }
                                        else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 'r':
                    {
                        if(cadena[1] == 'e')
                        {
                            if(cadena[2] == 'm')
                            {
                                if(cadena[3] == 'o')
                                {
                                    if(cadena[4] == 'v')
                                    {
                                        if(cadena[5] == 'e')
                                        {
                                            if(cadena[6] == ' ')
                                            {
                                                if(cadena[7] == '1' || cadena[7] == '2'|| cadena[7] == '3' || cadena[7] == '4'||cadena[7] == '5' || cadena[7] == '6')
                                                {
                                                	if(useWindows(cadena[7])!=0){
                                                    	Eliminar_PCB(cadena[7]);
                                               			Limpian_Pantalla((int)cadena[7]-48);
                                               		}
                                                }
                                                else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                            }
                                            else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                        }
                                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 'c':
                    {
                        if(cadena[1] == 'l')
                        {
                            if(cadena[2] == 'e')
                            {
                                if(cadena[3] == 'a')
                                {
                                    if(cadena[4] == 'r')
                                    {
                                        if(cadena[5] == ' ')
                                        {
                                            if(cadena[6] == '1' || cadena[6] == '2'|| cadena[6] == '3' || cadena[6] == '4'||cadena[6] == '5' || cadena[6] == '6')
                                            {
                                            	if(useWindows(cadena[6])!=0){
                                                	Limpian_Pantalla((int)cadena[6]-48);
                                                }
                                            }
                                           else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                        }
                                        else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 'q':
                    {
                        if(cadena[1] == 'u')
                        {
                            if(cadena[2] == 'a')
                            {
                                if(cadena[3] == 'n')
                                {
                                    if(cadena[4] == 't')
                                    {
                                        if(cadena[5] == 'u')
                                        {
                                            if(cadena[6] == 'm')
                                            {
                                                if(cadena[7] == ' ')
                                                {
                                                    if(cadena[8] == '1' || cadena[8] == '2'|| cadena[8] == '3' || cadena[8] == '4'||cadena[8] == '5' || cadena[8] == '6')
                                                    {
                                                    	if(useWindows(cadena[8])!=0){
															if(cadena[9] == ' ')
															{
																for(int i=0; i<sizeof( vectQ ); ++i)
																	vectQ[i]= '\0';
																while(cadena[xQ] != '$' && posQ < 6)
																{
																	vectQ[posQ] = cadena[xQ];
																	posQ++;
																	xQ++;
																}
																CambiarQuantum_PCB(cadena[8],atoi(vectQ));
															} else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
														}
                                                    }
                                                    else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                                }
                                                else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                            }
                                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                        }
                                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 's':
                    {
                    	if(cadena[1] == 't')
                     	{
                      		if(cadena[2]=='a')
                      		{
                       			if(cadena[3]=='t')
                       			{
                        			if(cadena[4]=='s')
                        			{
                         				if(cadena[5]==' ')
                         				{
                         					if(cadena[6] == '1' || cadena[6] == '2'||cadena[6] == '3' || cadena[6] == '4'||cadena[6] == '5' || cadena[6] == '6')
                              				{
                              					if(useWindows(cadena[6])!=0){
	                                       		 	ColocarCursor(1,22);
	                                                float por = stats(numventanas);
	                                                printf("Ventana %c -> %.2f%c", cadena[6], por,'%');
	                                            }
                                            }
											else{ ColocarCursor(25,19); printf("Se esperaba el # de ventana.");break;}
                                        }
                                        else{ ColocarCursor(25,19); printf("Se esperaba un espacio.");break;}
                                    }
                                    else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                                }
                                else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                            }
                            else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        }
                        else{ ColocarCursor(25,19); printf("Comando mal escrito.");break;}
                        break;
                    }
                case 'e':
                {
                	if(cadena[1] == 'x')
                    {
                     	if(cadena[2]=='i')
                      	{
                      		if(cadena[3]=='t')
	                      	{
	                      		exit = 1;
	                      	}
                      	}
                    }
                }
                default:
                    break;
             } 
        }
 
/*----------------------------------------------------------------------------------------------------------------*/
        int Kernel::Get_PosX(int pantallax)
		{ //metooo que devuelve posicion x inicial de la pantalla
		  switch(pantallax) {
			        case 1:
			        case 4:
			            return 1; 
			        case 2:
			        case 5:
			            return 2+20;
			        case 3:
			        case 6:
			            return 3+(20*2);
			        default:
			            return 0;
			}
		}

		int Kernel::Get_PosY(int pantallay)
		{ //metodo que devuelve la posicion y inicial de la pantalla
			        if(pantallay > 0 && pantallay < 4) {
			            return 2;
			        }
			        else if (pantallay >= 4 && pantallay < 7){
			            return 10;
			        }
			        else{
			            return 0;
			        }
		}
/*-------------------------------- Determina que ventana es la que se esta utilizando -----------------------------*/
        int Kernel::AreaWindow(int x, int y)
        {
          //pantalla 1
          if (x>1&&x<20&&y>1&&y<7){return 1;}
          //pantalla 2 
          else if (x>21&&x<41&&y>1&&y<7){return 2;}
          //pantalla 3 
          else if (x>42&&x<61&&y>1&&y<7){return 3;}
          //pantalla 4 
          else if (x>1&&x<20&&y>9&&y<15){return 4;}
          //pantalla 5
          else if (x>21&&x<41&&y>9&&y<15){return 5;}
          //pantalla 6
          else if (x>42&&x<61&&y>9&&y<15){return 6;}
            else {return 0;}
        }
 /*----------------------------------------------------------------------------------------------------------------*/
/*-------------------------------------- Detección del Mouse ------------------------------------------------------*/          
        int Kernel::ReiniciarMouse()
        {
          union REGS regin, regout;
          regin.x.ax = 0;
          int86(0x33, &regin, &regout);
          if((int)regout.x.ax == 0)
          {
            printf("No hay un mouse instalado \n");
            return -1;
          }
          else 
          {
            //printf("Raton listo para utilizarse\n");
            regin.x.ax = 1;
            int86(0x33, &regin, &regout);
          }
          return 1;
        }
        int Kernel::DetectarMouse ()
        {
           union REGS regin, regout;
           regin.x.ax = 3;
           int86(0x33, &regin, &regout);
           if(((int)regout.x.bx ==1) && (Click_presionado == 0))
           {
	            xMouse = ((int)regout.x.cx/8);
	            yMouse = ((int)regout.x.dx/8);
				pantallaMouse = AreaWindow(xMouse,yMouse);
	          	if (pantallaMouse!=0)
	            {
		            V_pos[pantallaMouse-1][yMouse-Get_PosY(pantallaMouse)][xMouse-Get_PosX(pantallaMouse)]='#';
	            }
	            Click_presionado = 1;
	            return 1;
           }
           if((int)regout.x.bx == 0)
           {
           		Click_presionado = 0;
           }
           return -1;
        }
/*----------------------------------------- Mètodo que limpia el teclado -----------------------------------*/
		void Kernel::Limpiar_Comando()
        {
          ColocarCursor(1,19);
          for(int q=0;q<16;++q)
          {
             printf(" ");
          }
        }
        void Kernel::Limpiar_Comando_error()
        {
          ColocarCursor(25,19);
          for(int q=0;q<36;++q)
          {
             printf(" ");
          }
        }
        void Kernel::Imprimir_Pantalla()
        {
          ColocarCursor(1,22);
          for(int q=0;q<20;++q)
          {
             printf(" ");
          }
        }
/*-------------------------------------------- Render Kenerl ---------------------------------------------*/
        void RenderKernel()
        {
            /*-----------------Ventanas de la 1 a la 3--------------------------------*/
            cout << "" << endl;
            printf("%c", 201);
            for(int m=1;m<62;++m){
            	if(m==20 || m == 21){
			  		printf("%c", 203);
			  	}else if(m==41 || m==42){
			  		printf("%c", 203);
			  	}
			  	else{			     
			  		printf("%c", 205);
			  	}
            }
            printf("%c\n", 187);
            for (int i=0;i<5;i++)
            {
			printf("%c                   %c", 186,186); printf("%c                   %c", 186, 186); printf("%c                   %c\n", 186, 186);
            }
            printf("%c", 204);
			  for(int k=1;k<62;++k)
			  {
			  	if(k==20 || k == 21){
			  		printf("%c", 202);
			  	}else if(k==41 || k==42){
			  		printf("%c", 202);
			  	}
			  	else{			     
			  		printf("%c", 205);
			  	}
			  }
  			printf("%c\n", 185); printf("%c         1                   2                    3          %c\n", 186, 186);
             
            /*---------------------------Ventanas de la 4 a la 6---------------------------------------*/
            printf("%c", 204);
            for(int l=1;l<62;++l){
            	if(l==20 || l == 21){
			  		printf("%c", 203);
			  	}else if(l==41 || l==42){
			  		printf("%c", 203);
			  	}
			  	else{			     
			  		printf("%c", 205);
			  	}
            }
            printf("%c\n", 185);
            for (int h=0;h<5;++h)
            {
            printf("%c                   %c", 186, 186);printf("%c                   %c", 186, 186);printf("%c                   %c\n", 186, 186);
            }
            printf("%c", 204);
			  for(int e=1;e<62;++e)
			  {
			     if(e==20 || e == 21){
			  		printf("%c", 202);
			  	}else if(e==41 || e==42){
			  		printf("%c", 202);
			  	}
			  	else{			     
			  		printf("%c", 205);
			  	}
			  }
  			printf("%c\n", 185); 
  			printf("%c         4                   5                    6          %c\n", 186, 186);
  			printf("%c", 200);
			for(int o=1;o<62;++o)
			  {			     
			  		printf("%c", 205);
			  }
			printf("%c\n", 188);
            printf("%c", 201);
            for(int q=1;q<62;++q){
            	if(q==20){
			  		printf("%c", 203);
			  	}else{
				printf("%c", 205);}
            }
            printf("%c\n", 187);
            printf("%c                   %cE:                                       %c\n", 186, 186,186);
            printf("%c", 200);
            for(int w=1;w<62;++w){
            	if(w==20){
			  		printf("%c", 202);
			  	}else{
				printf("%c", 205);}
            }
            printf("%c\n", 188);
            printf("%c", 201);
            for(int f=1;f<62;++f){
            	printf("%c", 205);
            }
            printf("%c\n", 187);
            printf("%c                                                             %c\n", 186, 186);
            printf("%c", 200);
            for(int z=1;z<62;++z){
            	printf("%c", 205);
            }
            printf("%c\n", 188);
        }
		 void Kernel::Imprimir_Pantalla(int pa, char _ma[5][18])
		{
		   for (int i = 0; i < 5; ++i)
		   {
		      for (int j = 0; j < 18; ++j)
		      {
					ColocarCursor(Get_PosX(pa)+j,Get_PosY(pa)+i);
					printf("%c", ' ');
					delay(1);
			        ColocarCursor(Get_PosX(pa)+j,Get_PosY(pa)+i);       
			        printf("%c", V_pos[pa-1][i][j]);
		      }
		   }
		}
		void Kernel::Teclado(){
			if(kbhit())
							{
								Limpiar_Comando_error();
                        		Imprimir_Pantalla();
								if(pos_cadena < 16){
								pos_cadena++;
								ColocarCursor(pos_cadena,19);
								teclapresionada = getch();
								if(teclapresionada==8){
									if(pos_cadena > 1)
								   {
									pos_cadena--;
									ColocarCursor(pos_cadena+1,19);
									printf(" ");
									pos_cadena--;
									cadena[pos_cadena] = teclapresionada;
									ColocarCursor(pos_cadena+1,19);
								   }
								   else if (pos_cadena == 1)
								   {
									pos_cadena--;
									ColocarCursor(1,19);
									printf(" ");
									ColocarCursor(1,19);
									pos_cadena = 0;
									}
								}else if (teclapresionada==13)
									{
										cadena[pos_cadena-1] = '$';
										AnalizarEntradaTeclado(cadena);
										Limpiar_Comando();
										ColocarCursor(1,19);
										pos_cadena=0;
									}
									else
									{
										printf("%c", teclapresionada);
										cadena[pos_cadena-1] = tolower(teclapresionada);
									}
								}
							}
		}
		void Kernel::Ejecutar_PCB(){
			if(getCurrent() != NULL){
				if (current->estadoPCB != PAUSE)
					{
						long int ms = clock();
									int endTime = ms + current->quantum;
									while(clock() <= endTime)
									{
										//DetectarMouse();
										Teclado();
										Imprimir_Pantalla(current->ventana-48, current->ma);
									}
								}
								nextPCB();
							}
		}
		//Ejecuta el Proyecto
		void Kernel::EjecutarSO()
		{
			timer t;
        	t.start();
        	struct timeval tp;
				ReiniciarMouse();
				RenderKernel();
				ColocarCursor(1,19);
				Actualizar_matris();
				while(1)
				{
					DetectarMouse();
					Teclado();
					Ejecutar_PCB();
				}
		}

 int main()
	{
		_setcursortype(_NOCURSOR);
		Kernel *h = new Kernel();
		h->EjecutarSO();
        return 0;
}
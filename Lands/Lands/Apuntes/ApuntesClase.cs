using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Apuntes
{
    class ApuntesClase
    {

        /*
            Xamarin 2018-I / Complete Course / Part 006 (Login Page)
            Fecha: 18-11-2021
            Obs: Diseño terminado
        */

        /*
            Xamarin 2018-I / Complete Course / Part 007 (Login View Model)
            Fecha: 18-11-2021
            Obs: Enlazando paginas con views
        */

        /*
            Xamarin 2018-I / Complete Course / Part 008 (INotifyPropertyChanged)
            Fecha: 18-11-2021
            Obs: Generando propiedades de controles
        */

        /*
            Xamarin 2018-I / Complete Course / Part 009 (Load Countries - API Service)
            Fecha: 18-11-2021
            Obs: Consumiendo servicios
            https://www.youtube.com/watch?v=JIFT4GY1qFg
            servicio
            https://restcountries.com/v2/all    
            https://restcountries.com/v3.1/all
            https://json2csharp.com/ //convierte json a csharp
        */
        /*
            Xamarin 2018-I / Complete Course / Part 010 (Load Countries - API Service)
            Fecha: 25-08-2022
            Obs: Configurando propiedades JSON para consumir servicio de paises
         */
        /*
            Xamarin 2018-I / Complete Course / Part 011 (Load Countries - API Service)
            Fecha: 25-08-2022
            Obs: Configurando propiedades JSON para consumir servicio de paises
         */
        /*
         *  Xamarin 2018-I / Complete Course / Part 012 (Check internet connection)
            Fecha: 25-08-2022
            Obs: Configurando propiedades JSON para consumir servicio de paises
            https://www.youtube.com/watch?v=KjejhmCblek
            
            Android Asset Studio
            icnos personalizados
            https://romannurik.github.io/AndroidAssetStudio/
         */

        /*
            Xamarin 2018-I / Complete Course / Part 013 (Show lands in a ListView)
            Fecha: 31-08-2022
            Obs: Listando paises en listview y cuadro de busqueda
            https://www.youtube.com/watch?v=vgDASBxOZMU
            Parametro de 
                <ListView
                HasUnevenRows="true" permite filas de diferente tamaño, ocupa mas de un renglon sin importar
                                    tamaño de letra
                IsPullToRefreshEnabled="true" refresca lista con vista hacia abajo/arriba
                >
            
         <SearchBar //buscador
                BackgroundColor="Silver"
                Text="{Binding Filter, Mode=TwoWay}" //lo que ejecuta cuando se digita texto  
                                    Binding Filter: propiedad filtro
                Placeholder="Search...." //texto que aparece para buscar
                SearchCommand="{Binding SearchCommand}" //ejecuta comando buscador
                >                
            </SearchBar>
         */

        /*
            Xamarin 2018-I / Complete Course / Part 014 (Show Land Detail)
            Fecha: 01-09-2022
            Obs: Listando paises en listview y mejorando grid                  
            https://www.youtube.com/watch?v=Zo4N-i2CsfA

            imagenes para celulares
            https://romannurik.github.io/AndroidAssetStudio/
         */

        /*
            Xamarin 2018-I / Complete Course / Part 015 (Show Land Detail)
            Fecha: 25-09-2023
            Obs: Muestra detalle de país seleccionado en otra pagina
            https://www.youtube.com/watch?v=8ZJoAUMGjL0
          
        /*
            Xamarin 2018-I / Complete Course / Part 016 (Tabbed Page)
            Fecha: 03-10-2023
            Obs: Crea pestañas
            https://www.youtube.com/watch?v=p-0s0exqG94

            Los recursos y documentos los puede descargar de:

            https://www.dropbox.com/s/r1np2ggok9g...
        */

        /*
            Xamarin 2018-I / Complete Course / Part 017 (Show Country Borders)
            Fecha: 03-10-2023
            Obs: Muestra frontera de país seleccionado en pestaña desde una colección
                1. Falta corregir cuando país seleccionado no tiene frontera sale error 03-11-2023
            https://www.youtube.com/watch?v=1WBAYPznvlQ
        /*
        
        
        /*
            Xamarin 2018-I / Complete Course / Part 018 (Other Pages in Tab)
            Fecha: 03-11-2023
            Obs: Otros tabs                
            https://www.youtube.com/watch?v=Gwm_K_i7JAI
        /*
        

        /*
            Xamarin 2018-I / Complete Course / Part 019 (Backend projects)
            Fecha: 03-11-2023
            Obs:              
            https://www.youtube.com/watch?v=l6DZgtHTLNE
        /*

        /*
            Xamarin 2018-I / Complete Course / Part 020 (Generate Token)
            Fecha: 17-12-2023
            Obs:              
            https://www.youtube.com/watch?v=pY4IfR6Og1E


            Azure: Crear cuenta en azure y crear servidor y base de datos sql
            Servidor:	aldoserver.database.windows.net
            usuario:	Zulu
            Contraseña:	Admin123456
            base de datos:	Afrodita    
        
            connectionString="Data Source=aldoserver.database.windows.net;Initial Catalog=Afrodita;Persist Security Info=True;User ID=Zulu;Password=Admin123456"
            publco: https://landsbackend1.azurewebsites.net/
         */

        /*
            Xamarin 2018-I / Complete Course / Part 020 (Generate Token)
            Fecha: 21-12-2023
            Obs:
            https://www.youtube.com/watch?v=pY4IfR6Og1E
            
            POSTMAN:https://localhost:44312/Token  'dirección local y agregar metodo Token
            POST/BODY:
            grant_type: password
            UserName:   contsoft@gmail.com
            password:   123456
            
            publico:    https://landsapi1.azurewebsites.net/
            usr: jzuluaga55@gmail.com
            pwd:    123456
         */

        /*
            Xamarin 2018-I / Complete Course / Part 021 (Login with service)
            Fecha: 23-12-2023
            Obs: publicar apis en azure y comprobar
            https://www.youtube.com/watch?v=wyijztkrI3k

         */


    }
}

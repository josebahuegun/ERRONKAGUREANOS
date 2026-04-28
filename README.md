# ERRONKAGUREANOS
3. Erronkaren GITHUB.
 GUREANOS ERRONKA

##  Proiektuaren deskribapena

Proiektu hau **Gureanos Erronka**-ren barruan garatutako aplikazio bat da.
Helburua da **ikastetxeko gailuen kudeaketa** egitea: sortu, aldatu, ezabatu eta kontsultatu.

Aplikazioak erabiltzaile mota desberdinak kudeatzen ditu, bakoitzak bere baimenekin.

---

##  Erabiltzaile rolak

* **IKT arduraduna**

  * Erabiltzaileak sortu, aldatu eta ezabatu
  * Erabiltzaileak aktibatu/desaktibatu
  * Mintegiak kudeatu
  * Gailuak kudeatu

* **Mintegiburua**

  * Bere mintegiko gailuak bakarrik kudeatu
  * Ezin du beste mintegietako datuak aldatu

* **Irakaslea**

  * Kontsulta bakarrik (ikusi)

---

##  Funtzionalitate nagusiak

* ✔ Gailuak sortu, aldatu eta ezabatu
* ✔ Gailuen historiala gordetzea
* ✔ Zaborrontzia (ezabatutako gailuak)
* ✔ Erabiltzaileen kudeaketa
* ✔ Erabiltzaileak aktibatu/desaktibatu
* ✔ Mintegien kudeaketa
* ✔ Rol bidezko baimen sistema

---

##  Datu-basea

Aplikazioak **MySQL** erabiltzen du.

Taula nagusiak:

* `gailua`
* `ordenagailua`
* `inprimagailua`
* `erabiltzailea`
* `mintegia`
* `zaborrontzia`
* `historikoa`

---

##  Teknologiak

* 💻 C# (.NET - Windows Forms)
* 🗄️ MySQL
* 🔗 MySql.Data
* 📄 GhostDoc (dokumentazioa)

---

##  Nola exekutatu

1. Klonatu repositorioa:

```bash
git clone https://github.com/zure-erabiltzailea/zure-proiektua.git
```

2. Ireki Visual Studio-rekin

3. Konfiguratu konexioa:

```csharp
server=192.168.80.21;database=GureanosErronkaDB;user=joseba;password=1234;
```

4. Exekutatu aplikazioa

Administratzaileak:
user = admin
password = 1234

Beste erabiltzaileak sortu, aplikazioa bertan aukera dago sortzeko

##  Segurtasuna

* Rol bidezko sarbide kontrola
* Mintegiburuek ezin dute beste mintegietako datuak aldatu
* Ezin da mintegi bat ezabatu erabiltzaileak baditu
* Ezin da azken IKT erabiltzailea aldatu

---

##  Hobekuntzak (etorkizuna)

* 🔄 Gailuak berreskuratzeko aukera (zaborrontzitik)
* 🔍 Bilaketa eta filtro sistema
* 🌐 Web bertsioa

---

##  Egileak

* Joseba Huegun eta Unai Zabaleta



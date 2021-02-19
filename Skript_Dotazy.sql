/*1;1;20;
Výpis všech záznamù tabulky Cvicenec seøazených podle vìku sestupnì.*/
SELECT *
FROM Cvicenec
ORDER BY vek desc

/*1;2;1;
Vypíše vìk nejstaršího cvièence*/
SELECT MAX(Cvicenec.vek) as Nejstarsi_cvicenec
FROM Cvicenec

/*1;3;1;
Vypíše cenu nejlevnìjší lekce.*/
SELECT MIN(Lekce.cena) as Nejnizsi_cena
FROM Lekce

/*1;4;10;
Vypíše id_zmeny, id_lekce, id_trenera a druh_zmeny seøazených dle data provedení*/
SELECT Zmeny.id_zmeny, Zmeny.id_lekce, Zmeny.id_trenera, Zmeny.druh_zmeny
FROM Zmeny
ORDER BY MONTH(Zmeny.cas_zmeny), DAY(Zmeny.cas_zmeny)


/*2;1;5;
Vypíše všechny lekce, které nepožadují èlenství v klubu a jejich cena je mezi 20 vèetnì a 40 vèetnì.*/
SELECT Lekce.id_lekce, Lekce.cena, Lekce.clenstvi
FROM Lekce
WHERE Lekce.clenstvi = 0 AND Lekce.cena BETWEEN 20 AND 40

/*2;2;7;
Vypíše všechny muže, kteøí jsou starší 40-ti let vèetnì, nebo mladší 30-ti let vèetnì*/
SELECT Cvicenec.jmeno, Cvicenec.prijmeni, Cvicenec.vek, Cvicenec.email
FROM Cvicenec
WHERE Cvicenec.pohlavi LIKE 'Muž' AND (Cvicenec.vek >= 40 OR cvicenec.vek <= 30)


/*2;3;4;
Vypíše všechny trenéry jejichž jméno nezaèíná písmenem "J".*/
SELECT Trener.id_trenera, Trener.jmeno, Trener.prijmeni, Trener.email
FROM Trener
WHERE Trener.jmeno NOT LIKE 'J%'

/*2;4;2; 
Vypíše všechny lekce, které se konají v øíjnu a jejich zaokrouhlenou cenu v polských zlotych(kurz aktuální k 5.12.2019).*/
SELECT Lekce.id_lekce, CEILING(Lekce.cena / 5.97) as Cena_v_Polskych_Zlotych
FROM Lekce
WHERE MONTH(Lekce.cas_konani) = 10

/*3;1;4;
Vypíše id_trenera všech, kteøí netrénují Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
EXCEPT (
			SELECT Trenerova_specializace.id_trenera 
			FROM Trenerova_specializace 
			WHERE Trenerova_specializace.id_treninku = 4
		)

/*3;2;4;
Vypíše id_trenera všech, kteøí netrénují Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE NOT EXISTS  (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )

/*3;3;4;
Vypíše id_trenera všech, kteøí netrénují Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE Trener.id_trenera != ALL 
				 (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )
/*3;4;4;
Vypíše id_trenera všech, kteøí netrénují Aerobik(id_treninku = 4).*/
SELECT Trener.id_trenera
FROM Trener
WHERE Trener.id_trenera NOT IN 
				  (
					SELECT Trenerova_specializace.id_trenera 
					FROM Trenerova_specializace 
					WHERE Trener.id_trenera = Trenerova_specializace.id_trenera AND Trenerova_specializace.id_treninku = 4
				  )

/*4;1;1;
Vypíše prùmìrný vìk trenérù.*/
SELECT AVG(Trener.vek) as Prumerny_vek
FROM Trener

/*4;2;19;
Vypíše jméno a pøíjmení Cvicence a kolikrát se pøihlásil na lekci.*/
SELECT Cvicenec.jmeno, Cvicenec.prijmeni, COUNT(*) as Pocet_prihlaseni
FROM Cvicenec
JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence AND Prihlaseni_cvicenci.Ucast = 1
GROUP BY Cvicenec.jmeno, Cvicenec.prijmeni

/*4;3;4;
Vypíše jméno a pøíjmení trenérù, kteøí vypsali 3 a více tréninkù.*/
SELECT Trener.id_trenera, Trener.jmeno, Trener.prijmeni
FROM Trener
JOIN Lekce ON Lekce.id_trenera = Trener.id_trenera
GROUP BY Trener.id_trenera, Trener.jmeno, Trener.prijmeni
HAVING COUNT(*) >= 3

/*4;4;20;
Vypíše id_lekce a jejich oèekávanou tržbu seøazenou vzestupnì.*/
SELECT Lekce.id_lekce, SUM(Lekce.Cena) AS Trzba_za_Lekci
FROM Lekce
JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_lekce = Lekce.id_lekce AND Prihlaseni_cvicenci.Ucast = 1
GROUP BY Lekce.id_lekce
ORDER BY Trzba_za_lekci

/*5;1;9;
Vypíše id_lekce všech u kterých probìhla nìjaká zmìna.*/
SELECT DISTINCT Lekce.id_lekce
FROM Lekce
JOIN Zmeny ON Zmeny.id_lekce = Lekce.id_lekce


/*5;2;9;
Vypíše id_lekce všech u kterých probìhla nìjaká zmìna.*/
SELECT  Lekce.id_lekce
FROM Lekce
WHERE Lekce.id_lekce IN (SELECT Zmeny.id_lekce FROM Zmeny)

/*
5;3;20;
Vypíše všechny lekce a k nim poèet provedených zmìn, vypíšou se i ty lekce beze zmìny.*/
SELECT Lekce.id_lekce, COUNT(Zmeny.id_lekce) as Pocet_Zmen
FROM Lekce 
LEFT JOIN Zmeny ON Zmeny.id_lekce = Lekce.id_lekce
GROUP BY Lekce.id_lekce

/*5;4;4;
Vypíše poèet pøihlášení na lekci všech mužù starších 30 let.*/
SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni, COUNT(*) AS Pocet_prihlaseni
FROM Cvicenec
LEFT JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence AND Prihlaseni_cvicenci.Ucast = 1 
WHERE Cvicenec.vek > 30 AND Cvicenec.pohlavi LIKE 'Muž'
GROUP BY Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni


/*6;1;20;
Vypíše všechny cvièence a jejich poèet pøihlášení na silový trénink.*/
SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni,
	(
		SELECT COUNT(*) as pocet
		FROM Prihlaseni_cvicenci
		JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
		JOIN Trenerova_specializace ON Trenerova_specializace.id_trenera = Lekce.id_trenera
		WHERE Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
			  AND Prihlaseni_cvicenci.Ucast = 1
			  AND Trenerova_specializace.id_treninku = 5
	) as Pocet_Prihlaseni
FROM Cvicenec

/*6;2;1;
Vypíše cvièence, který za lekce utratil nejvíce i s touto èástkou.*/
SELECT utrata.id_cvicence, utrata.jmeno, utrata.prijmeni, MAX(utrata.Utrata) as  Nejvetsi_utrata
FROM (
		SELECT Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni, SUM(Lekce.cena) as Utrata
		FROM Cvicenec
		JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
			 AND Prihlaseni_cvicenci.Ucast = 1
		JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
		GROUP BY Cvicenec.id_cvicence, Cvicenec.jmeno, Cvicenec.prijmeni
	 ) utrata
GROUP BY utrata.id_cvicence, utrata.jmeno, utrata.prijmeni
HAVING MAX(utrata.Utrata) >= ALL( SELECT u1.Utrata FROM(
															SELECT Cvicenec.id_cvicence, SUM(Lekce.cena) as Utrata
															FROM Cvicenec
															JOIN Prihlaseni_cvicenci ON Prihlaseni_cvicenci.id_cvicence = Cvicenec.id_cvicence 
																AND Prihlaseni_cvicenci.Ucast = 1
															JOIN Lekce ON Lekce.id_lekce = Prihlaseni_cvicenci.id_lekce
															GROUP BY Cvicenec.id_cvicence
														) u1
							    )








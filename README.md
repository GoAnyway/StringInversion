# StringInversion

1 часть.

Создать Windows приложение с использованием WPF.

1. Нарисовать форму , на ней кнопка, элемент с выпадающим списком, текст филд
2. Текст филд редактируемый, то что в него вносим по нажатию кнопки записывается в БД в табличку №1
3. В БД, в табличке №2 должен вестись лог каждой записи, которая происходит в табличку №1 (например дата/время)
4. В элемент с выпадающим списком всегда выводится то что в БД в табличке №1 и №2 (продумать).
5. При выборе какого либо значения в выпадающем списке, оно отображается в текст боксе и позволяет себя редактировать и записать.


2 часть.

1. Разработать программу написанную на С++ (или просто С)  (версия не важна). Программа должна принимать строку, и возвращать ее инверсию, длина строки - не более 100 символов. 
2. Разработанный код необходимо скомпилировать в виде DLL файла и EXE файла (используя например MinGw).
3. Обеспечить возможность использования (подключения) DLL сборки к С# проекту (тестового задания).
4. Обеспечить возврат преобразованной строки в переменную C# проекта, а так же типизировать функцию DLL как int и возвращать число 777 в случае успеха, 666 в случае ошибки преобразования строки. 
5. В С# проекте (WPF задание) необходимо реализовать метод инверсии строки с использованием подключаемой DLL. Для инверсии можно использовать любое изменяемое или вводимое пользователем поле из задания по WPF на усмотрение разработчика.

% Локализация
:- encoding(utf8).

/*
ABCDEFGH
биолог - E, G
гидролог - B, F
синоптик - F, G
радист - C, D
механик - C, H
врач - A, D

F только с B
D только с C
C без G
A без B
*/

not_the_same([]).
not_the_same([X|T]) :-
    \+ member(X, T),
    not_the_same(T).

print_list([]).
print_list([E|List]) :-
	write(E),
	nl,
	print_list(List).

start :-
    % Перебираем все варианты назначений
    (Biologist = e ; Biologist = g),
    (Hydrologist = b ; Hydrologist = f),
    (Synoptic = f ; Synoptic = g),
    (Radioman = c ; Radioman = d),
    (Mechanic = c ; Mechanic = h),
    (Doctor = a ; Doctor = d),

    % Ставим условие, что люди не должны повторяться
    not_the_same([Biologist, Hydrologist, Synoptic, Radioman, Mechanic, Doctor]),

    People = [Biologist, Hydrologist, Synoptic, Radioman, Mechanic, Doctor],

    % Проверка пожеланий
    (member(f, People) -> member(b, People) ; true),
    (member(d, People) -> member(c, People) ; true),
    (member(c, People) -> \+ member(g, People) ; true),
    (member(a, People) -> \+ member(b, People) ; true),

    print_list([биолог-Biologist, гидролог-Hydrologist, синоптик-Synoptic, радист-Radioman, механик-Mechanic, врач-Doctor]).

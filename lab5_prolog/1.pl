% Локализация
:- encoding(utf8).

% Базовый случай
divisors_in(N, I, [N]) :-
    I > floor(N // 2).

% Делитель подходит - добавляем в конец списка
divisors_in(N, I, [I|Res]) :-
    I =< floor(N // 2),
    N mod I  =:= 0,
    I1 is I + 1,
    divisors_in(N, I1, Res).

% Делитель не подходит
divisors_in(N, I, Res) :-
    I =< floor(N // 2),
    I1 is I + 1,
    divisors_in(N, I1, Res).


% Ф-я обертка
divisors(N) :-
    divisors_in(N, 1, Res),
    write('Делители числа '), write(N), write(': '), write(Res), nl.


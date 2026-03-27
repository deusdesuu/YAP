% Локализация
:- encoding(utf8).

% Проверка на четность
check_even(N, N) :-
    N mod 2 =:= 0.
check_even(_, 0).

% Сумма четных
sum_even(List, Sum) :-
    maplist(check_even, List, Tmp),
    sum_list(Tmp, Sum).

start :-
    write('Введите список целых чисел:'),
    read(List),
    sum_even(List, Sum),
    write('Сумма четных чисел = '),
    write(Sum).

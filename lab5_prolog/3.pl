/*
    not(A+B) = not(A) & not(B)
    Задаем универсальное, А, В
    U = [1..10],
    A = [1, 2, 3],
    B = [6, 7]

    not(A + B) = [4, 5, 8, 9, 10]
    not(A) & not(B) = [4..10] & [1..5,8..10] = [4, 5, 8, 9, 10]
*/
% Локализация
:- encoding(utf8).

% Принадлежность
in(X, [X|_]).
in(X, [_|T]) :-
    in(X, T).

% Отрицание
negate([], _, []).
negate([X|U], A, Res) :-
    in(X, A),
    negate(U, A, Res).
negate([X|U], A, [X|Res]) :-
    negate(U, A, Res).

% Объединение
union([], B, B).
union([X|A], B, Res) :-
    in(X, B),
    union(A, B, Res).
union([X|A], B, [X|Res]) :-
    union(A, B, Res).

% Пересечение
intersect(_, [], []).
intersect(A, [X|B], [X|Res]) :-
    in(X, A),
    intersect(A, B, Res).
intersect(A, [_|B], Res) :-
    intersect(A, B, Res).

% not(A + B)
de_morgan_left(U, A, B, Res) :-
    union(A, B, Tmp),
    negate(U, Tmp, Res).

% not(A) & not(B)
de_morgan_right(U, A, B, Res) :-
    negate(U, A, NotA),
    negate(U, B, NotB),
    intersect(NotA, NotB, Res).

start :-
    write('Введите универсальное множество U:'),
    read(U),
    write('Введите множество A:'),
    read(A),
    write('Введите множество B:'),
    read(B),
    de_morgan_left(U, A, B, Left),
    de_morgan_right(U, A, B, Right),
    write('Левая часть равенства not(A + B): '),
    write(Left),
    nl,
    write('Правая часть равенства not(A) & not(B): '),
    write(Right).

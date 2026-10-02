# Komendy Git z tutoriala (csharp.mini.pw.edu.pl/pl/labs/01.git)

## Konfiguracja i pomoc

- **`git --version`** — sprawdza, czy Git jest zainstalowany i jaką ma wersję. Używaj na starcie, żeby zweryfikować instalację.
- **`git config --global user.name <nazwa>`** — ustawia globalną nazwę użytkownika podpisującą commity. Ustaw raz po instalacji Gita.
- **`git config --global user.email <email>`** — ustawia globalny email użytkownika podpisujący commity. Ustaw raz po instalacji Gita.
- **`git help`** — pokazuje listę najczęściej używanych poleceń. Gdy nie pamiętasz, jakich komend używać.
- **`git <polecenie> --help`** — pełna dokumentacja danego polecenia. Gdy potrzebujesz szczegółów o konkretnej komendzie.
- **`git <polecenie> -h`** — skrócony opis opcji danego polecenia. Szybka ściąga z flag bez otwierania pełnego manuala.

## Tworzenie repozytorium i podstawowy workflow

- **`git init`** — tworzy nowe repozytorium Git w bieżącym katalogu. Na początku nowego projektu.
- **`git status`** — pokazuje stan repo: co zmodyfikowane, co w staging area, co nieśledzone. Używaj często, przed każdym commitem.
- **`git add <plik>`** — dodaje konkretny plik do staging area (przygotowuje do commita).
- **`git add .`** — dodaje wszystkie zmiany w bieżącym katalogu i podkatalogach. Szybkie, ale sprawdź `git status` najpierw, żeby nie dodać czegoś niechcianego (np. plików z sekretami).
- **`git commit -m "<wiadomość>"`** — tworzy commit ze zmianami ze staging area i podaną wiadomością.
- **`git push`** — wysyła lokalne commity do repozytorium zdalnego.

## Podgląd zmian (diff)

- **`git diff`** — pokazuje niezatwierdzone (niezastaged) zmiany w plikach względem ostatniego commita.
- **`git diff --staged`** — pokazuje zmiany, które są już w staging area i trafią do następnego commita.
- **`git diff HEAD`** — pokazuje wszystkie zmiany (staged + niestaged) względem ostatniego commita.
- **`git diff <commit1> <commit2>`** — porównuje dwa konkretne commity.
- **`git diff --stat`** — krótkie podsumowanie zmian (liczba linii dodanych/usuniętych na plik), bez szczegółów treści.
- **`git diff --name-only`** — wypisuje tylko nazwy zmodyfikowanych plików, bez treści zmian.

## SSH i repozytoria zdalne

- **`ssh-keygen -t ed25519 -C "<email>"`** — generuje parę kluczy SSH (algorytm ed25519) z komentarzem w postaci maila. Używane do uwierzytelniania się wobec GitHub/GitLab bez hasła przy każdym push/pull.
- **`cat ~/.ssh/id_ed25519.pub`** — wypisuje zawartość klucza publicznego, który wklejasz np. w ustawieniach GitHuba.
- **`git clone <link>`** — pobiera istniejące repozytorium ze zdalnego serwera razem z całą historią.
- **`git remote add origin <link>`** — podpina lokalne repo pod zdalne repozytorium o nazwie `origin`. Używane po `git init`, gdy repo zdalne już istnieje, ale lokalnie jeszcze go nie podłączono.
- **`git branch -M main`** — zmienia nazwę bieżącej gałęzi na `main` (np. z domyślnego `master`).
- **`git push -u origin main`** — wypycha commity do zdalnej gałęzi `main` i ustawia śledzenie (tracking), dzięki czemu później wystarczy samo `git push`.
- **`git fetch`** — pobiera nowe commity ze zdalnego repo, ale nie scala ich z lokalnymi plikami. Bezpieczny sposób sprawdzenia, co nowego jest zdalnie, zanim coś zmergujesz.
- **`git pull`** — pobiera (fetch) i od razu scala (merge) zmiany ze zdalnej gałęzi do lokalnej.

## Historia commitów

- **`git log`** — pokazuje pełną historię commitów ze szczegółami (autor, data, wiadomość, hash).
- **`git log --oneline`** — skrócona historia, jeden commit na linię. Szybki przegląd historii.
- **`git log --oneline --graph --all`** — historia wszystkich gałęzi w formie wizualnego grafu z połączeniami. Przydatne do zrozumienia, jak gałęzie się rozchodzą i łączą.

## Praca z gałęziami (branch)

- **`git branch`** — wypisuje listę lokalnych gałęzi.
- **`git branch <nazwa>`** — tworzy nową gałąź (bez przełączania się na nią).
- **`git switch <nazwa>`** — przełącza się na istniejącą gałąź.
- **`git switch -c <nazwa>`** — tworzy nową gałąź i od razu się na nią przełącza (skrót `branch` + `switch`).
- **`git push -u origin <nazwa_brancha>`** — wypycha nową gałąź do zdalnego repo i ustawia śledzenie.
- **`git merge <nazwa_gałęzi>`** — scala wskazaną gałąź z bieżącą. Używane, gdy chcesz włączyć zmiany z jednej gałęzi do drugiej.
- **`git merge --abort`** — przerywa trwający merge (np. przy konfliktach) i przywraca stan sprzed scalania.

## Cofanie zmian

- **`git restore <plik>`** — przywraca plik do wersji z ostatniego commita, kasując niezatwierdzone zmiany lokalne. Uważaj — to nieodwracalne dla danego pliku.
- **`git restore --staged <plik>`** — wyjmuje plik ze staging area (odwrotność `git add <plik>`), ale zostawia zmiany w plikach.
- **`git commit --amend`** — modyfikuje ostatni commit (np. zmienia wiadomość lub dorzuca zapomniane zmiany) zamiast tworzyć nowy. Nie używaj na commitach, które już wypchnięto współdzielone repo, bo zmienia historię.
- **`git reset --soft <commit>`** — cofa historię do wskazanego commita, ale zmiany zostają w staging area (gotowe do ponownego commitu).
- **`git reset --mixed <commit>`** — cofa historię, zmiany trafiają z powrotem jako niezastaged (domyślny tryb `reset`).
- **`git reset --hard <commit>`** — cofa historię i trwale kasuje zmiany w plikach roboczych. Destrukcyjne — gubi niezapisane zmiany.
- **`git reset --soft HEAD~1`** — cofa ostatni commit, ale zmiany z niego zostają w staging area (można je poprawić i zacommitować ponownie).
- **`git reset --hard HEAD`** — kasuje wszystkie lokalne zmiany w śledzonych plikach, wracając do stanu ostatniego commita.
- **`git reset --hard HEAD~1`** — całkowicie usuwa ostatni lokalny commit razem z jego zmianami.
- **`git revert <commit>`** — tworzy nowy commit, który odwraca zmiany ze wskazanego commita. Bezpieczny sposób cofania zmian w historii już wypchniętej współdzielonej, bo nie usuwa istniejących commitów.
- **`git rm --cached <plik>`** — usuwa plik ze śledzenia przez Gita (przestaje go śledzić), ale nie kasuje go z dysku. Przydatne np. gdy przypadkiem dodano plik, który powinien być w `.gitignore`.

## Narzędzia .NET powiązane z repo

- **`dotnet new gitignore`** — generuje gotowy szablon pliku `.gitignore` dla projektów .NET.
- **`dotnet new console`** — tworzy nową aplikację konsolową w C#.

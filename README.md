# Basarsoft Harita OpenLayers

ufak bi .NET proje. içinde WEB, Core, Application ve Infrastructure katmanları var.

## ne var burada?

- `WEB`: api ve basit login ekranı
- `Core`: entity ler
- `Application`: dto lar
- `Infrastructure`: db ve veri işleri

## calıstırma

```bash
dotnet run --project WEB
```

veya

```bash
cd WEB
dotnet run
```

## not

Login ekranı sade tutuldu. form gönderince `/api/auth/login` isteği atıyor.

Projede `bin` ve `obj` klasorleri git e girmez, normalde gerek de yok zaten.

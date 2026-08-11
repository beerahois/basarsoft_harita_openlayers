x# Basarsoft Harita OpenLayers

ufak bi .NET proje. içinde WEB, Core, Application ve Infrastructure katmanları var.

## Teknolojiler

- .NET 8
- React 
- OpenLayers

## proje yapısı

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

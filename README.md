# 🌍 TauschBar – Die geldfreie Tauschbörse für Nachbarschaft & Gemeinschaft

TauschBar ist eine moderne Webanwendung, in der Menschen **gebrauchte Dinge** oder **Hilfsleistungen** anbieten und im Gegenzug etwas anderes erhalten – ganz ohne Geld.  
Ob **Fahrrad gegen Rasenmähen**, **Nachhilfe gegen Möbelstück** oder **Hilfe gegen Hilfe** – TauschBar bringt Menschen auf Augenhöhe zusammen.

---

## 🚀 Ziel
- **Peer-to-Peer-Tauschplattform** für Dinge und Nachbarschaftshilfe
- Fokus auf **soziale Interaktion statt Bezahlung**
- Modernes, skalierbares Tech-Setup (React, .NET, Docker)

---

## 🧩 Features (MVP)
- Benutzerregistrierung & Login
- Angebote: **Ich biete / Ich suche**
- Tauscharten:  
  - Ware ↔ Ware  
  - Ware ↔ Hilfe  
  - Hilfe ↔ Hilfe
- Tauschvorschläge & Match-Flow
- Filterung nach Kategorien / Regionen (später)
- Optional: Bewertungsfunktion & Nachrichten

---

## ⚙️ Tech-Stack

| Bereich       | Technologie                  |
|---------------|------------------------------|
| **Frontend**  | Next.js (React, TypeScript), Tailwind CSS |
| **Backend**   | .NET 8 (C#), Minimal API, EF Core |
| **Datenbank** | SQLite (lokal), PostgreSQL (optional) |
| **Auth**      | JWT (JSON Web Tokens) |
| **DevOps**    | Docker, GitHub Actions |
| **Deployment**| Vercel (Frontend), Render/Azure (Backend) |

---

## 📁 Projektstruktur

```bash
tauschbar/
├── tauschbar-api/     # .NET Backend (Minimal APIs)
├── tauschbar-app/     # Next.js Frontend (TypeScript)
├── README.md


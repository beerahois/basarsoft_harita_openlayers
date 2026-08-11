function App() {
  return React.createElement(
    "main",
    { className: "page" },
    React.createElement(
      "form",
      {
        className: "login-card",
        onSubmit: (event) => event.preventDefault(),
      },
      React.createElement("h1", { className: "baslik" }, "Basarsoft"),
      React.createElement("input", {
        type: "username",
        placeholder: "username",
      }),
      React.createElement("input", {
        type: "password",
        placeholder: "Password",
      }),
      React.createElement("button", { type: "submit" }, "Gonder"),
    ),
  );
}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(React.createElement(App));

function App() {
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleLogin = async (event) => {
    event.preventDefault();

    try {
      const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });

      const data = await response.json();

      if (response.ok) {
        localStorage.setItem("jwt_token", data.token);
        window.location.href = "/map.html";
      } else {
        console.error(data.message);
        alert(data.message);
      }
    } catch (error) {
      console.error("hata", error);
      alert("hata");
    }
  };

  return React.createElement(
    "main",
    { className: "page" },
    React.createElement(
      "form",
      {
        className: "login-card",
        onSubmit: handleLogin,
      },
      React.createElement("h1", { className: "baslik" }, "Basarsoft"),
      React.createElement("input", {
        type: "text",
        placeholder: "username",
        value: username,
        onChange: (event) => setUsername(event.target.value),
        autoComplete: "username",
      }),
      React.createElement("input", {
        type: "password",
        placeholder: "Password",
        value: password,
        onChange: (event) => setPassword(event.target.value),
        autoComplete: "current-password",
      }),
      React.createElement("button", { type: "submit" }, "Gonder"),
    ),
  );
}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(React.createElement(App));

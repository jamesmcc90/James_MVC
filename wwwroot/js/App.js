import React from 'react';
import logo from './logo.svg';
import image from './edinburgh.jpg'
import ReactDOM from "react-dom";
import './App.css';
import { useFormik } from 'formik';

function App() {
    return (
        <div className="App" style={{ backgroundColor: "red" }}>

            <header className="App-header">
                <body>
                    <h2>Welcome to some (very basic) React testing!</h2>
                </body>

                <img src={logo} className="App-logo" alt="logo" />
                <img src={image} className="edinburghImage" style={{ width: 600, height: 400 }} alt="edinburgh" />

                <p>
                    This is a new React app - pretty cool!
                </p>

                <a className="App-link" href="https://reactjs.org" target="_blank" rel="noopener noreferrer" style={{ paddingBottom: 30 }}>James McConnell</a>

            </header>

            <h1>Test</h1>
            <p style={{ float: "left" }}>Testing React</p>

        </div>




    );

    const SignupForm = () => {
        const formik = useFormik({
            initialValues: { email: "" },
            onSubmit: values => {
                alert(JSON.stringify(values, null, 2));
            }
        });
        return (
            <form onSubmit={formik.handleSubmit}>
                <label htmlFor="email">Email Address</label>
                <input
                    id="email"
                    name="email"
                    type="email"
                    onChange={formik.handleChange}
                    value={formik.values.email}
                />
                <button type="submit">Submit</button>
            </form>
        );
    };

    function App() {
        return <SignupForm />;
    }

    const rootElement = document.getElementById("root");
    ReactDOM.render(<App />, rootElement);
}


export default App;
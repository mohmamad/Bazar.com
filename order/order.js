const express = require("express");
const app = express();
const bodyParser = require("body-parser");
const sqlite3 = require("sqlite3").verbose();
const axios = require("axios");



let catalogServer = 1;
const toggleCatalogServer = () => {
  const server = `http://localhost:300${catalogServer}`;
  catalogServer = (catalogServer % 2) + 1;
  return server;
};
app.use(bodyParser.json());

app.get("/purchase/:id", async (req, res) => {
  try {
    const { id } = req.params;

    const serverUrl = toggleCatalogServer();
    const response = await axios.get(
      `${serverUrl}/Bazarcom/purchase/${id}`
    );
    console.log(response.data);
    const message = response.data;
    res.json({ message });
  } catch (err) {
    return res.json({ message: "An error has occured", err });
  }
});



app.listen(4001, () => {
  console.log("order server is running 4001");
});

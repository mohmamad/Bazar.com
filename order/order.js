const express = require("express");
const app = express();
const bodyParser = require("body-parser");
const axios = require("axios");



app.use(bodyParser.json());

app.get("/purchase/:id", async (req, res) => {
  try {
    const { id } = req.params;

    const serverUrl = `https://localhost:7093/api/catalog`;
    const response = await axios.get(
      `${serverUrl}/${bookId}/purchase`
    );
    console.log(response.data);
    const message = response.data;
    res.json({ message });
  } catch (err) {
    return res.json({ message: "An error has occured", err });
  }
});



app.listen(5001, () => {
  console.log("order server is running 5001");
});

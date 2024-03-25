import express from "express";

const app = express();
const port = 3000;

app.get("/", (req, res) => {
  res.send(`Hello ${req.query.name}!`);
});

app.get("/redirect", (req, res) => {
  const url = req.query.url;

  if (url) {
    res.status(302).redirect(url as string);
  } else {
    res
      .status(400)
      .send('Use the query parameter "url" to specify the URL to redirect to.');
  }
});

app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});

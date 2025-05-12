export const Weather = () => {
    return (
    <>
      <p>Buenos Aires, Argentina.</p>
      <div className="weather-container">
        <div className="weather_title"> 
          <b>El tiempo actual</b>
        </div>
        <div className="weather">
          <div className="weather-temp">
            <p>🌙</p>
            <h2>17°C</h2>
          </div>
          <div>
            <b>Despejado</b>
            <p>Sensacion termica de 16°</p>
          </div>
        </div>
        <p>El cielo estará despejado. La temperatura minima sera de 14°</p>
        <div className="weather-details">
          <div>
            <p className="weather-details_title">Viento</p>
            <p>4km p/h</p>
          </div>
          <div>
            <p className="weather-details_title">Humedad</p>
            <p>60%</p>
          </div>
          <div>
            <p className="weather-details_title">Visibilidad</p>
            <p>10km</p>
          </div>
          <div>
            <p className="weather-details_title">Presion</p>
            <p>1015hPa</p>
          </div>
          <div>
            <p className="weather-details_title">Punto de Rocio</p>
            <p>10°</p>
          </div>
        </div>
      </div>
    </>
    )
}
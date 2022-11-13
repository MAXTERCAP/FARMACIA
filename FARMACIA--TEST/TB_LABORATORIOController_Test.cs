using Farmacia.Controllers;
using Moq;


namespace FARMACIA__TEST
{
    public class TB_LABORATORIOController_Test
    {

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfLaboratoriosAsync()
        {

            // Arrange
            var mockRepo = new Mock<IBrainstormLaboratoriosRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestLaboratorios());
            var controller = new TB_LABORATORIOController(mockRepo.Object);


            // Act
            var result = await controller.Index();


            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Laboratorios>>(
                viewResult.ViewData.Model);
            Assert.Equal("Bago", model1[0].nombre);
            Assert.Equal(2, model.Count());
        }


        private List<Laboratorios> GetTestLaboratorios()
            {
                var laboratorios = new List<Laboratorios>();
                laboratorios.Add(new Laboratorios()
                {
                    Laboratorio = 1,
                    NomLab = "Bago"
                });
                laboratorios.Add(new Laboratorios()
                {
                    Laboratorio = 2,
                    NomLab = "Bayer"
                });
                return laboratorios;
            }

                
    }
}
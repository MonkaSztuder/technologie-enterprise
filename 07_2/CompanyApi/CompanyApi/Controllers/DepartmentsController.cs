using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyApi.Models;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public DepartmentsController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentDTO>>> GetDepartments()
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            return await _context.Departments.Select(x => DepartamentToDTO(x)).ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentDTO>> GetDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return DepartamentToDTO(department);
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartamentDTO department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(DTOToDepartment(department)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartamentDTO>> PostDepartment(DepartamentDTO department)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'CompanyDbContext.Departments'  is null.");
            }
            _context.Departments.Add(DTOToDepartment(department));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Departments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }


        private static DepartamentDTO DepartamentToDTO(Department department) =>
            new DepartamentDTO
            {
                DepartmentId = department.DepartmentId,
                Name = department.Name
            };
        private static Department DTOToDepartment(DepartamentDTO departmentDTO) =>
            new Department
            {
                DepartmentId = departmentDTO.DepartmentId,
                Name = departmentDTO.Name
            };
    }

}
